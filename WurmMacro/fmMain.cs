using MacroLib;
using System;
using System.Diagnostics;
using System.Drawing;
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
            dgTimer.DataSource = client.timers;
        }

        private void OnRecvLog(object sender, EventArgs e)
        {
            //ログ受信
            var line = ((RecvLogEventArgs)e).Line;
            if (1000 < tbLog.TextLength)
            {
                tbLog.Text = line + "\r\n";
            }
            else
            {
                tbLog.Text += line + "\r\n";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("クライアントが見つかりません。 \r\n" + ex.Message);
                btStop_Click(null, null);
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            client.IsExecute = false;
            client.Dispose();
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
        }
    }
}
