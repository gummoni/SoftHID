using MacroLib;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WurmMacro
{
    public partial class fmMain : Form
    {
        Client client;
        public fmMain()
        {
            InitializeComponent();

            client = Client.Create();
            client.OnRecvLog += OnRecvLog;
            pgSetting.SelectedObject = client;
            dgCommand.DataSource = client.methods;

            //トリガー読込み
            tbTrigger.Text = File.ReadAllText(client.matchingPath);
            //マクロ読込み
            var files = Directory.GetFiles(client.scriptsPath, "*.txt", SearchOption.TopDirectoryOnly);
            var items = files.Select(_ => Path.GetFileNameWithoutExtension(_)).ToArray();
            lbScript.Items.Clear();
            lbScript.Items.AddRange(items);
        }

        private void OnRecvLog(object sender, EventArgs e)
        {
            //ログ受信
            var line = ((RecvLogEventArgs)e).Line;
            SetLog(line);
        }

        delegate void dlgSetLog(string line);
        void SetLog(string line)
        {
            if (tbLog.InvokeRequired)
            {
                tbLog.Invoke((dlgSetLog)SetLog, new[] { line });
            }
            else
            {
                if (1000 < tbLog.TextLength)
                {
                    tbLog.Text = line + "\r\n";
                }
                else
                {
                    tbLog.Text += line + "\r\n";
                }
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                client.Initialize();
                client.IsExecute = true;
                btStop.BackColor = Color.LightGray;
                btStart.BackColor = Color.Lime;
                btTest.Enabled = true;
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("クライアントが見つかりません。 \r\n" + ex.Message);
                btStop_Click(null, null);
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            client.IsExecute = false;
            client.Stop();
            btTest.Enabled = false;
            btStop.BackColor = Color.Lime;
            btStart.BackColor = Color.LightGray;
        }

        private void btScript_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.CurrentDirectory);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            client.Save();
            //トリガー保存
            File.WriteAllText(client.matchingPath, tbTrigger.Text);

            //マクロ保存(選択中のマクロを保存)
            SaveScript();
        }

        int selectedIndex = -1;
        void SaveScript()
        {
            if (0 <= selectedIndex)
            {
                //保存
                var path = Path.Combine(client.scriptsPath, $"{(string)lbScript.Items[selectedIndex]}.txt");
                var text = tbScript.Text;
                File.WriteAllText(path, text);
            }
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            //テストログ送信
            var message = tbTest.Text;
            client.SetMessage(message);
        }

        private void pgSetting_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //プロパティが変更されたら保存
            btSave_Click(null, null);
        }

        private void lbScript_SelectedIndexChanged(object sender, EventArgs e)
        {
            //スクリプトリストビューの選択項目が変更された

            //現在編集中のスクリプトを保存する
            SaveScript();

            //次のスクリプトを読み込む
            selectedIndex = lbScript.SelectedIndex;
            var path = Path.Combine(client.scriptsPath, $"{(string)lbScript.Items[selectedIndex]}.txt");
            var text = File.ReadAllText(path);
            tbScript.Text = text;
        }

        private void fmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            btStop_Click(null, null);
            client.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                tbTimer.Text = client.timers.ToString();
            }
            else
            {
                tbTimer.Text = "";
            }
        }

    }
}
