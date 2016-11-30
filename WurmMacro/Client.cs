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
using MacroLib.Jobs;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
        #region "テンプレート画像管理"
        Dictionary<string, MatBitmap> images = new Dictionary<string, MatBitmap>();
        /// <summary>
        /// 画像取得
        /// </summary>
        /// <param name="imageName"></param>
        /// <returns></returns>
        MatBitmap GetImage(string imageName)
        {
            if (!images.ContainsKey(imageName))
            {
                images[imageName] = new MatBitmap($".\\Templates\\{imageName}.bmp");
            }
            return images[imageName];
        }
        #endregion


        //Writing to d:\game\wurm\players\gummo\logs\_Friends.2016-11.txt
        public string ProcessName { get; set; } = "jp2launcher";
        readonly internal string matchingPath = "matching.txt";
        readonly internal string passivesPath = Path.Combine(Environment.CurrentDirectory, "Passives");
        readonly internal string scriptsPath = Path.Combine(Environment.CurrentDirectory, "Scripts");
        readonly string templatePath = Path.Combine(Environment.CurrentDirectory, "Templates");
        public string InstallPath { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "wurm", "players");
        public string UserName { get; set; } = "gummo";
        public string PassiveScript { get; set; }   //ユーザー設定(起動するパッシブスクリプトは選択してもらう)
        string eventLogPath => Directory.GetFiles(Path.Combine(InstallPath, UserName, "logs")).FirstOrDefault(_ => _.Contains($"_Event.{DateTime.Now.Year}-{DateTime.Now.Month}.txt"));
        string combatLogPath => Directory.GetFiles(Path.Combine(InstallPath, UserName, "logs")).FirstOrDefault(_ => _.Contains($"_Combat.{DateTime.Now.Year}-{DateTime.Now.Month}.txt"));
        Thread timerThread { get; set; }
        JobSpooler spooler = new JobSpooler();

        readonly Encoding encode = Encoding.GetEncoding(932);
        internal Controller controller;     // キー・マウス・画面操作
        internal Reader eventReader;        // イベントログ
        internal Reader combatReader;       // コンバットログ
        internal Passives passives;         // パッシブ一覧
        internal Scripts scripts;           // スクリプト一覧
        internal Matchings matchings;       // マッチング一覧
        internal Timers timers;             // 実行中タイマー一覧
        internal MatBitmap[] templates;     // テンプレート画像
        internal Methods methods;           // 命令一覧

        [Browsable(false)]
        public bool IsExecute { get; set; } = false;
        bool IsPower = false;

        Match match;                        //メモ用マッチングしたデータ

        public event EventHandler OnRecvLog;
        public event EventHandler OnRecvMemo;

        /// <summary>
        /// スケジューラタイムアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// ログ受信イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// テキストマッチングイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Matchings_OnMatching(object sender, EventArgs e)
        {
            //マッチングしたから実行
            var script = ((MatchingEventArgs)e).ScriptName;
            match = ((MatchingEventArgs)e).Match;
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
        
        /// <summary>
        /// コンストラクタ処理
        /// </summary>
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
                Dispatch(passives[PassiveScript]);
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

            if (!Directory.Exists(passivesPath)) Directory.CreateDirectory(passivesPath);
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
            passives = new Passives(passivesPath);
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

        /// <summary>
        /// 停止処理
        /// </summary>
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

        /// <summary>
        /// 開放処理
        /// </summary>
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
            if (null == lines) return;

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

        /// <summary>
        /// タイマーセット
        /// </summary>
        /// <param name="alarmName"></param>
        /// <param name="doScriptName"></param>
        /// <param name="timerCount"></param>
        [Command("タイマーをセットします")]
        public void TimerSet(string alarmName, string doScriptName, int timerCount)
        {
            lock (timers)
            {
                timers.Add(alarmName, doScriptName, timerCount);
            }
        }

        [Command("タイマーを停止します")]
        public void TimerStop(string alarmName)
        {
            lock (timers)
            {
                var model = timers.FirstOrDefault(_=>_.AlarmName == alarmName);
                if (null != model)
                {
                    timers.Remove(model);
                }
            }
        }

        [Command("タイマーが起動していたらスクリプトを実行します")]
        public void TimerOnStart(string alarmName, string scriptName)
        {
            lock (timers)
            {
                var model = timers.FirstOrDefault(_ => _.AlarmName == alarmName);
                if (null != model)
                {
                    Dispatch(scripts[scriptName]);
                }
            }
        }

        [Command("タイマーが停止していたらスクリプトを実行します")]
        public void TimerOffStart(string alarmName, string scriptName)
        {
            lock (timers)
            {
                var model = timers.FirstOrDefault(_ => _.AlarmName == alarmName);
                if (null == model)
                {
                    Dispatch(scripts[scriptName]);
                }
            }
        }

        [Command("画像マッチングしたらカーソル移動")]
        public void IconMove(string imageName)
        {
            try
            {
                var tempImage = GetImage(imageName);
                var pos = controller.Snapshot().Search(tempImage);
                Cursor.Position = pos;
            }
            catch
            {
                //見つからなかった
            }
        }

        [Command("画像マッチングしたらカーソル移動してからスクリプト実行")]
        public void IconMoveStart(string imageName, string doScript)
        {
            try
            {
                var tempImage = GetImage(imageName);
                var pos = controller.Snapshot().Search(tempImage, true);
                Cursor.Position = pos;
                Dispatch(scripts[doScript]);
            }
            catch
            {
                //見つからなかった
            }
        }

        [Command("マッチングパターンでマッチした文字列をメモする")]
        public void WriteMemo(string groupName)
        {
            var line = match.Groups[groupName].Value;
            OnRecvMemo?.Invoke(this, new RecvLogEventArgs(line));
        }
    }
}
