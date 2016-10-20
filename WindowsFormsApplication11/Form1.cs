using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class Form1 : Form
    {

        public Form1()
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

        private void button2_Click(object sender, EventArgs e)
        {
            client.AbortScript();
        }
    }
}
