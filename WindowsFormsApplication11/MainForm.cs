using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {
            testwurm();
        }

        WurmSettingData settings;
        WurmClient client;
        void testwurm()
        {
            settings = WurmSettingData.Load();
            settings.LogPath = "test.log";
            settings.WindowName = "svchost";
            settings.PassiveList.Add(new LogAnalyzeModel("hello", "Test.Hello"));
            settings.PassiveList.Add(new LogAnalyzeModel("world", "Test2.World"));
            settings.PassiveList.Add(new LogAnalyzeModel("foo", "Test.Foo"));
            settings.PassiveList.Add(new LogAnalyzeModel("bar", "Test2.Bar"));
            settings.PassiveList.Add(new LogAnalyzeModel("ok", "Test.ok"));
            settings.PassiveList.Add(new LogAnalyzeModel("pk", "Test2.pk"));
            settings.Save();

            var lines1 = new List<string>();
            lines1.Add("action left , Test.Hello | !DO.LEFT");
            lines1.Add("action right, Test.Foo   | !DO.RIGHT   | !DO.UP");
            lines1.Add("action up   , Test.Foo   | Test2.Bar   | !DO.UP");
            lines1.Add("action down , Test.Hello | Test2.World | !DO.DOWN");
            File.WriteAllLines(Path.Combine(WurmSettingData.scriptsDir, "test.txt"), lines1);

            File.WriteAllLines(Path.Combine(WurmSettingData.scriptsDir, "left.txt"), new string[] { "MouseMoveRelative -100,0", "ChangeState DO.LEFT" });
            File.WriteAllLines(Path.Combine(WurmSettingData.scriptsDir, "right.txt"), new string[] { "MouseMoveRelative +100,0", "ChangeState DO.RIGHT" });
            File.WriteAllLines(Path.Combine(WurmSettingData.scriptsDir, "up.txt"), new string[] { "MouseMoveRelative 0,-100", "ChangeState DO.UP" });
            File.WriteAllLines(Path.Combine(WurmSettingData.scriptsDir, "down.txt"), new string[] { "MouseMoveRelative 0,+100", "ChangeState DO.DOWN" });


            using (client = settings.Create())
            {
                client.StartScript("test.txt");

                using (var sw = new StreamWriter(settings.LogPath, true, Encoding.GetEncoding(932)))
                {
                    sw.WriteLine("hello");
                }
                Task.Delay(500).Wait();

                using (var sw = new StreamWriter(settings.LogPath, true, Encoding.GetEncoding(932)))
                {
                    sw.WriteLine("foo");
                }
                Task.Delay(500).Wait();

                using (var sw = new StreamWriter(settings.LogPath, true, Encoding.GetEncoding(932)))
                {
                    sw.WriteLine("bar");
                }
                Task.Delay(500).Wait();

                using (var sw = new StreamWriter(settings.LogPath, true, Encoding.GetEncoding(932)))
                {
                    sw.WriteLine("ok");
                    sw.WriteLine("pk");
                }
                Task.Delay(500).Wait();
            }
        }

        void test()
        { 
            Process.Start("notepad");
            Thread.Sleep(500);

            using (var controller = new GUI("notepad"))
            {
                //HUD動作チェック
                controller.WindowActivate();
                controller.KeyPress("!!!!!hello World!\r\n");
                controller.MouseMoveAbsolute(100, 100);
                controller.MouseRightClick();

                //LogReaderチェック
                resp.Clear();
                using (var logger = new LogReader("test.log", Encoding.GetEncoding(932)))
                {
                    logger.ReadLineRecieved += Logger_ReadLineRecieved;

                    using (var sw = new StreamWriter("test.log", true, Encoding.GetEncoding(932)))
                    {
                        sw.WriteLine("hello");
                    }
                    Task.Delay(500).Wait();
                    using (var sw = new StreamWriter("test.log", true, Encoding.GetEncoding(932)))
                    {
                        sw.WriteLine("world");
                    }
                    Task.Delay(500).Wait();

                    logger.ReadLineRecieved -= Logger_ReadLineRecieved;
                }

                if (2 != resp.Count)
                {
                    throw new InvalidProgramException();
                }
                if ("hello" != resp[0])
                {
                    throw new InvalidProgramException();
                }
                if ("world" != resp[1])
                {
                    throw new InvalidProgramException();
                }
                resp.Clear();

                //Consoleチェック
                var con = new ObjectConsole<GUI>(controller);
                foreach (var line in con.Help())
                {
                    Console.WriteLine(line);
                }
                con.Execute("MouseMoveAbsolute 50,100");
                con.Execute("MouseLeftClick");
                con.Execute("    KeyPress Foo bar\r\n");
            }
        }

        List<string> resp = new List<string>();
        private void Logger_ReadLineRecieved(object sender, string e)
        {
            resp.Add(e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadLogFolder();
            loadPassiveEvent();
            loadPassiveCombat();
            loadAction();
            loadMacro();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            saveLogFolder();
            savePassiveEvent();
            savePassiveCombat();
            saveMacro();
            saveAction();
            loadMacro();
            loadAction();
        }

        #region "GUI周りの設定"
        static readonly string logPathFile = "logFolder.txt";
        static readonly string passiveEventFile = "passive_event.txt";
        static readonly string passiveCombatFile = "passive_combat.txt";
        static readonly string actionPath = "actions";
        static readonly string macroPath = "macros";

        void loadAction()
        {
            //アクションデータの読込み
            if (!Directory.Exists(actionPath))
            {
                Directory.CreateDirectory(actionPath);
            }
            var files = Directory.GetFiles(actionPath, "*.txt").Select(_ => Path.GetFileNameWithoutExtension(_)).ToArray();
            cbAction.Items.Clear();
            cbAction.Items.AddRange(files);
        }

        void saveAction()
        {
            //アクションデータの保存
            var filename = $"{cbAction.Text}.txt";
            var text = tbAction.Text;

            File.WriteAllText(Path.Combine(actionPath, filename), text);
        }

        void loadMacro()
        {
            //マクロデータの読込み
            if (!Directory.Exists(macroPath))
            {
                Directory.CreateDirectory(macroPath);
            }

            var files = Directory.GetFiles(macroPath, "*.txt").Select(_ => Path.GetFileNameWithoutExtension(_)).ToArray();
            cbMacro.Items.Clear();
            cbMacro.Items.AddRange(files);
        }

        void saveMacro()
        {
            //マクロデータの保存
            var filename = $"{cbMacro.Text}.txt";
            var text = tbMacro.Text;

            File.WriteAllText(Path.Combine(macroPath, filename), text);
        }

        void loadLogFolder()
        {
            //ログフォルダの読込み
            if (File.Exists(logPathFile))
            {
                var lines = File.ReadAllLines(logPathFile);
                if (0 < lines.Length)
                {
                    tbLogPath.Text = lines[0];
                }
            }
        }

        void saveLogFolder()
        {
            //ログフォルダの保存
            File.WriteAllText(logPathFile, tbLogPath.Text);
        }

        void loadPassiveEvent()
        {
            //パッシブーイベント向けスクリプトの読込み
            if (File.Exists(passiveEventFile))
            {
                tbPassiveEventScript.Text = File.ReadAllText(passiveEventFile);
            }
        }

        void savePassiveEvent()
        {
            //パッシブーイベント向けスクリプトの保存
            File.WriteAllText(passiveEventFile, tbPassiveEventScript.Text);
        }

        void loadPassiveCombat()
        {
            //パッシブーコンバット向けスクリプトの読込み
            if (File.Exists(passiveCombatFile))
            {
                tbPassiveCombatScript.Text = File.ReadAllText(passiveCombatFile);
            }
        }

        void savePassiveCombat()
        {
            //パッシブーコンバット向けスクリプトの保存
            File.WriteAllText(passiveCombatFile, tbPassiveCombatScript.Text);
        }
        #endregion
        #region "ログ監視"
        bool isPower = true;
        PassiveCollection passiveList = new PassiveCollection();
        Task watchTask;
        Task logReadTask() => Task.Run(() =>
        {
            //ログ監視
            var dt = DateTime.Now;
            var eventPath = Path.Combine(tbLogPath.Text, $"_Event.{dt.Year}-{dt.Month}.txt");
            var combatPath = Path.Combine(tbLogPath.Text, $"_Combat.{dt.Year}-{dt.Month}.txt");
            if (!File.Exists(eventPath)) throw new FileNotFoundException($"{eventPath} が存在していません。");
            if (!File.Exists(combatPath)) throw new FileNotFoundException($"{combatPath} が存在していません。");

            //開始
            using (var eventReader = new LogReader(eventPath, Encoding.GetEncoding(932)))
            using (var combatReader = new LogReader(combatPath, Encoding.GetEncoding(932)))
            {
                try
                {
                    eventReader.ReadLineRecieved += EventReader_ReadLineRecieved;
                    combatReader.ReadLineRecieved += CombatReader_ReadLineRecieved;

                    while (isPower)
                    {
                        Thread.Sleep(1);
                        //TODO:アクティブ動作
                    }
                }
                finally
                {
                    eventReader.ReadLineRecieved -= EventReader_ReadLineRecieved;
                    combatReader.ReadLineRecieved -= CombatReader_ReadLineRecieved;
                }
            }
        });

        private void EventReader_ReadLineRecieved(object sender, string e)
        {
            passiveList.Check(e);
            SetEventLog(e);
        }

        private void CombatReader_ReadLineRecieved(object sender, string e)
        {
            passiveList.Check(e);
            SetCombatLog(e);
        }

        delegate void dlgSetEventLog(string message);
        delegate void dlgSetCombatLog(string message);
        void SetEventLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new dlgSetCombatLog(SetEventLog), new[] { message });
            }
            else
            {
                tbEvent.Text += $"{message}\r\n";
            }
        }
        void SetCombatLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new dlgSetCombatLog(SetCombatLog), new[] { message });
            }
            else
            {
                tbCombat.Text += $"{message}\r\n";
            }
        }

        #endregion

        void btStart_Click(object sender, EventArgs e)
        {
            //サポツール開始・停止
            if (watchTask?.IsCompleted == false)
            {
                //停止
                isPower = false;
                btStart.BackColor = System.Drawing.Color.LightGray;
            }
            else
            {
                //開始

                //パッシブ一覧更新
                passiveList.Clear();
                passiveList.Append(tbPassiveEventScript.Lines);
                passiveList.Append(tbPassiveCombatScript.Lines);
                //状態別にまとめる
                var states = StateCollection.Create(passiveList);

                dgStatus.DataSource = null;
                dgStatus.DataSource = states;

                isPower = true;
                watchTask = logReadTask();
                btStart.BackColor = System.Drawing.Color.Lime;
            }
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            //1秒周期で画面更新
            dgStatus.Refresh();
        }

        void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            //アクションデータの読込み
            tbAction.Text = File.ReadAllText(Path.Combine(actionPath, $"{cbAction.Text}.txt"));
        }

        void cbMacroSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //マクロデータの読込み
            tbMacro.Text = File.ReadAllText(Path.Combine(macroPath, $"{cbMacro.Text}.txt"));
        }
    }

}
