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
                var con = new Console<GUI>(controller);
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
    }
}
