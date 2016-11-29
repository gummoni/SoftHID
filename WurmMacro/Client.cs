using MacroLib.Models;
using MacroLib.Outputs.Bitmaps;
using MacroLib.Outputs.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MacroLib.Jobs;

namespace MacroLib
{
    public class RecvLogEventArgs : EventArgs
    {
        public string Line { get; }

        public RecvLogEventArgs(string line)
        {
            Line = line;
        }
    }

    /// <summary>
    /// WurmClient
    /// </summary>
    public class Client
    {
        //Writing to d:\game\wurm\players\gummo\logs\_Friends.2016-11.txt
        public string ProcessName { get; set; } = "jp2launcher";
        readonly internal string matchingPath = "matching.txt";
        readonly internal string scriptsPath = Path.Combine(Environment.CurrentDirectory, "Scripts");
        readonly string templatePath = Path.Combine(Environment.CurrentDirectory, "Templates");
        public string InstallPath { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "wurm", "players");
        public string UserName { get; set; } = "gummo";
        string eventLogPath => Directory.GetFiles(Path.Combine(InstallPath, UserName, "logs")).FirstOrDefault(_ => _.Contains($"_Event.{DateTime.Now.Year}-{DateTime.Now.Month}.txt"));
        string combatLogPath => Directory.GetFiles(Path.Combine(InstallPath, UserName, "logs")).FirstOrDefault(_ => _.Contains($"_Combat.{DateTime.Now.Year}-{DateTime.Now.Month}.txt"));
        Thread timerThread { get; set; }
        JobSpooler spooler = new JobSpooler();

        readonly Encoding encode = Encoding.GetEncoding(932);
        internal Controller controller;     // キー・マウス・画面操作
        internal Reader eventReader;        // イベントログ
        internal Reader combatReader;       // コンバットログ
        internal Scripts scripts;           // スクリプト一覧
        internal Matchings matchings;       // マッチング一覧
        internal Timers timers;             // 実行中タイマー一覧
        internal MatBitmap[] templates;     // テンプレート画像
        internal Methods methods;           // 命令一覧

        [Browsable(false)]
        public bool IsExecute { get; set; } = false;
        bool IsPower = false;

        public event EventHandler OnRecvLog;

        private void OnTimeOut(object sender, EventArgs e)
        {
            //タイムアウトしたから実行
            var script = ((TimeoutEventHandler)e).ScriptName;
            try
            {
                OnRecvLog?.Invoke(this, new RecvLogEventArgs($"★OnTimeout->Do:{script}"));
                Dispatch(scripts[script]);
            }
            catch (Exception ex)
            {
                var line = $"スクリプトエラー:{script}" + "\r\n" + ex.Message;
                OnRecvLog?.Invoke(this, new RecvLogEventArgs(line));
            }
        }

        private void OnReadLineRecieved(object sender, EventArgs e)
        {
            //ライン受信したからマッチング解析
            var line = ((ReadLineEventArgs)e).Line;
            OnRecvLog?.Invoke(this, new RecvLogEventArgs(line));
            matchings.DoEvents(line);
        }

        /// <summary>
        /// デバッグ用メッセージセット
        /// </summary>
        /// <param name="line"></param>
        internal void SetMessage(string line)
        {
            OnRecvLog?.Invoke(this, new RecvLogEventArgs(line));
            matchings.DoEvents(line);
        }

        private void Matchings_OnMatching(object sender, EventArgs e)
        {
            //マッチングしたから実行
            var script = ((MatchingEventArgs)e).ScriptName;
            try
            {
                OnRecvLog?.Invoke(this, new RecvLogEventArgs($"★OnMatching->Do:{script}"));
                Dispatch(scripts[script]);
            }
            catch (Exception ex)
            {
                OnRecvLog?.Invoke(this, new RecvLogEventArgs($"スクリプトエラー:{script}" + "\r\n" + ex.Message));
            }
        }

        public Client()
        {
            methods = new Methods();
            methods.Add(typeof(Controller).GetMethods());
            methods.Add(typeof(Client).GetMethods());
        }

        /// <summary>
        /// タイマー実行周期
        /// </summary>
        void TimerMain()
        {
            while (IsPower)
            {
                timers.DoEvents();
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            if (IsPower) return;

            if (!Directory.Exists(scriptsPath)) Directory.CreateDirectory(scriptsPath);
            if (!Directory.Exists(templatePath)) Directory.CreateDirectory(templatePath);

            //GUI画面
            controller = new Controller(ProcessName);

            //イベント・コンバットログ
            eventReader = new Reader(eventLogPath, encode);
            combatReader = new Reader(combatLogPath, encode);
            eventReader.OnReadLineRecieved += OnReadLineRecieved;
            combatReader.OnReadLineRecieved += OnReadLineRecieved;

            //スクリプト
            scripts = new Scripts(scriptsPath);

            //トリガー
            if (!File.Exists(matchingPath)) File.WriteAllText(matchingPath, "");
            matchings = new Matchings(matchingPath);
            matchings.OnMatching += Matchings_OnMatching;

            //タイマー
            timers = new Timers();
            timers.OnTimeOut += OnTimeOut;

            //テンプレート
            var files = Directory.GetFiles(templatePath, "*.png", SearchOption.AllDirectories);
            templates = files.Select(_ => new MatBitmap(_)).ToArray();

            //タイマースレッド起動
            IsPower = true;
            timerThread = new Thread(TimerMain);
            timerThread.Start();
        }
        public void Stop()
        {
            if (!IsPower) return;

            IsPower = false;
            eventReader.OnReadLineRecieved -= OnReadLineRecieved;
            combatReader.OnReadLineRecieved -= OnReadLineRecieved;
            matchings.OnMatching -= Matchings_OnMatching;
            timers.OnTimeOut -= OnTimeOut;
            spooler.Clear();
        }

        public void Dispose()
        {
            Stop();
            spooler.Dispose();
        }

        /// <summary>
        /// マクロ実行
        /// </summary>
        /// <param name="lines"></param>
        void Dispatch(string[] lines)
        {
            foreach (var line in lines)
            {
                try
                {
                    Dispatch(line);
                }
                catch (Exception)
                {
                    throw new Exception(line);
                }
            }
        }

        /// <summary>
        /// マクロ実行
        /// </summary>
        /// <param name="line"></param>
        void Dispatch(string line)
        {
            if (!IsExecute) return;
            var commands = line.Trim().Split(',').Select(_ => _.Trim()).ToList();
            var command = commands[0];
            var arguments = new List<object>();
            commands.RemoveAt(0);
            var len = commands.Count;

            var cli = typeof(Client).GetMethod(command);
            if (null != cli)
            {
                var prms = cli.GetParameters();
                if (len != prms.Length) throw new ArgumentException("パラメータ数不一致");
                for (var idx = 0; idx < len; idx++)
                {
                    //変換
                    var value = Convert.Parse(prms[idx].ParameterType, commands[idx]);
                    arguments.Add(value);
                }

                spooler.Add(new Job(() => { cli.Invoke(this, arguments.ToArray()); }));
                return;
            }

            var com = typeof(Controller).GetMethod(command);
            if (null != com)
            {
                var prms = com.GetParameters();
                if (len != prms.Length) throw new ArgumentException("パラメータ数不一致");
                for (var idx = 0; idx < len; idx++)
                {
                    //変換
                    var value = Convert.Parse(prms[idx].ParameterType, commands[idx]);
                    arguments.Add(value);
                }

                spooler.Add(new Job(() => { com.Invoke(controller, arguments.ToArray()); }));
                return;
            }
        }

        /// <summary>
        /// 作成
        /// </summary>
        /// <returns></returns>
        public static Client Create()
        {
            if (File.Exists("setting.txt"))
            {
                return Json.Parse<Client>(File.ReadAllText("setting.txt"));
            }
            else
            {
                return new Client();
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            File.WriteAllText("setting.txt", Json.ToString(this, typeof(Client)));
        }


        [Command("タイマーをセットします")]
        public void SetTimer(string alarmName, string doScriptName, int timerCount)
        {
            lock (timers)
            {
                timers.Add(alarmName, doScriptName, timerCount);
            }
        }
    }
}
