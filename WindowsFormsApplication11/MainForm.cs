using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadLogFolder();
            loadPassiveEvent();
            loadPassiveCombat();
            loadMacro();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            saveLogFolder();
            savePassiveEvent();
            savePassiveCombat();
            saveMacro();
            loadMacro();
        }

        #region "GUI周りの設定"
        static readonly string logPathFile = "logFolder.txt";
        static readonly string passiveEventFile = "passive_event.txt";
        static readonly string passiveCombatFile = "passive_combat.txt";
        static readonly string macroPath = "macros";

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
        PassiveCollection passiveList = new PassiveCollection();
        LogReader eventReader;
        LogReader combatReader;

        bool keyHandled = false;
        void KeyListener_KeyDown(object sender, KeyEventArgs e)
        {
            //キー押下イベント
            var evt = e.KeyData.ToString().ToUpper();
            keyHandled = DoActive(evt);
            e.Handled = keyHandled;
        }

        void KeyListener_KeyUp(object sender, KeyEventArgs e)
        {
            //キー離れるイベント
            var evt = "!" + e.KeyData.ToString().ToUpper();
            DoActive(evt);
            e.Handled = keyHandled;
        }

        void EventReader_ReadLineRecieved(object sender, string e)
        {
            //イベントログ受信イベント
            SetEventLog(e);
            var events = passiveList.Check(e);
            DoActive(events);
        }

        private void CombatReader_ReadLineRecieved(object sender, string e)
        {
            //コンバットログ受信イベント
            SetCombatLog(e);
            passiveList.Check(e);
            DoActive();
        }

        delegate void dlgSetEventLog(string message);
        delegate void dlgSetCombatLog(string message);
        void SetEventLog(string message)
        {
            //イベントロク書き込み
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
            //コンバットログ書き込み
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
            if (btStart.BackColor == Color.Lime)
            {
                //停止
                btStart.BackColor = Color.LightGray;

                HID.KeyListener.Enabled = false;
                HID.KeyListener.KeyUp -= KeyListener_KeyUp;
                HID.KeyListener.KeyDown -= KeyListener_KeyDown;
                eventReader.ReadLineRecieved -= EventReader_ReadLineRecieved;
                combatReader.ReadLineRecieved -= CombatReader_ReadLineRecieved;
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

                btStart.BackColor = Color.Lime;

                //ログ監視
                var dt = DateTime.Now;
                var eventPath = Path.Combine(tbLogPath.Text, $"_Event.{dt.Year}-{dt.Month}.txt");
                var combatPath = Path.Combine(tbLogPath.Text, $"_Combat.{dt.Year}-{dt.Month}.txt");
                if (!File.Exists(eventPath)) throw new FileNotFoundException($"{eventPath} が存在していません。");
                if (!File.Exists(combatPath)) throw new FileNotFoundException($"{combatPath} が存在していません。");

                //開始
                eventReader = new LogReader(eventPath, Encoding.GetEncoding(932));
                combatReader = new LogReader(combatPath, Encoding.GetEncoding(932));
                HID.KeyListener.Enabled = true;
                eventReader.ReadLineRecieved += EventReader_ReadLineRecieved;
                combatReader.ReadLineRecieved += CombatReader_ReadLineRecieved;
                HID.KeyListener.KeyDown += KeyListener_KeyDown;
                HID.KeyListener.KeyUp += KeyListener_KeyUp;
            }
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            //1秒周期で画面更新
            dgStatus.Refresh();
            DoActive("TIMER");
        }

        void cbMacro_SelectedIndexChanged(object sender, EventArgs e)
        {
            //マクロデータの読込み
            tbMacro.Text = File.ReadAllText(Path.Combine(macroPath, $"{cbMacro.Text}.txt"));
        }

        bool DoActive(params string[] eventCode)
        {
            //アクティブマクロ実行(変化のあったイベントのみ実行)
            //TODO
            return true;
        }
    }

}
