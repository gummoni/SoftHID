using MacroLib.Models;
using MacroLib.Outputs.Bitmaps;
using MacroLib.Outputs.Files;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

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
        readonly public string ProcessName = "jp2launcher";
        readonly string mattingPath = "matting.txt";
        readonly string scriptsPath = Path.Combine(Environment.CurrentDirectory, "Scripts");
        readonly string templatePath = Path.Combine(Environment.CurrentDirectory, "Templates");
        public string InstallPath { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "wurm", "players");
        public string UserName { get; set; } = "gummo";
        string eventLogPath => Directory.GetFiles(Path.Combine(InstallPath, UserName)).Where(_ => _.Contains("event")).OrderBy(_ => File.GetLastAccessTime(_)).Reverse().ToArray()[0];
        string combatLogPath => Directory.GetFiles(Path.Combine(InstallPath, UserName)).Where(_ => _.Contains("combat")).OrderBy(_ => File.GetLastAccessTime(_)).Reverse().ToArray()[0];
        Thread timerThread { get; set; }

        readonly Encoding encode = Encoding.GetEncoding(932);
        internal Controller controller;     // キー・マウス・画面操作
        internal Reader eventReader;        // イベントログ
        internal Reader combatReader;       // コンバットログ
        internal Scripts scripts;           // スクリプト一覧
        internal Matchings matchings;       // マッチング一覧
        internal Timers timers;             // 実行中タイマー一覧
        internal MatBitmap[] templates;     // テンプレート画像

        [Browsable(false)]
        public bool IsExecute { get; set; } = false;
        bool IsPower = false;

        public event EventHandler OnRecvLog;

        private void OnTimeOut(object sender, EventArgs e)
        {
            //タイムアウトしたから実行
            var script = ((TimeoutEventHandler)e).ScriptName;
            Dispatch(scripts[script]);
        }

        private void OnReadLineRecieved(object sender, EventArgs e)
        {
            //ライン受信したからマッチング解析
            var line = ((ReadLineEventArgs)e).Line;
            OnRecvLog?.Invoke(this, new RecvLogEventArgs(line));
            matchings.DoEvents(line);
        }

        private void Matchings_OnMatching(object sender, EventArgs e)
        {
            //マッチングしたから実行
            var script = ((MatchingEventArgs)e).ScriptName;
            Dispatch(scripts[script]);
        }

        public void SetTimer(string alarmName, string doScriptName, int timerCount)
        {
            timers.Add(alarmName, doScriptName, timerCount);
        }

        public void Dispose()
        {
            if (!IsPower) return;
            IsPower = false;
            eventReader.OnReadLineRecieved -= OnReadLineRecieved;
            combatReader.OnReadLineRecieved -= OnReadLineRecieved;
            matchings.OnMatching -= Matchings_OnMatching;
            timers.OnTimeOut -= OnTimeOut;
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
            matchings = new Matchings(mattingPath);
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
        /// マクロ実行
        /// </summary>
        /// <param name="lines"></param>
        void Dispatch(string[] lines)
        {
            foreach (var line in lines)
            {
                Dispatch(line);
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
            commands.RemoveAt(0);
            var args = commands.Select(_ => (object)_).ToArray();
            if (command == "SetTimer")
            {
                typeof(Client).GetMethod(command)?.Invoke(this, args);
            }
            else
            {
                typeof(Controller).GetMethod(command)?.Invoke(controller, args);
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
    }
}
