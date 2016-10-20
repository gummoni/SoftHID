using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

                if (2 != console.Count)
                {
                    throw new InvalidProgramException();
                }
                if ("hello" != console[0])
                {
                    throw new InvalidProgramException();
                }
                if ("world" != console[1])
                {
                    throw new InvalidProgramException();
                }
            }
        }

        List<string> console = new List<string>();
        private void Logger_ReadLineRecieved(object sender, string e)
        {
            console.Add(e);
        }
    }

    public static class Convert
    {
        public static object Parse(Type type, string value)
        {
            if (type == typeof(string)) return value;
            if (type == typeof(byte)) return byte.Parse(value);
            if (type == typeof(sbyte)) return sbyte.Parse(value);
            if (type == typeof(ushort)) return ushort.Parse(value);
            if (type == typeof(short)) return short.Parse(value);
            if (type == typeof(uint)) return uint.Parse(value);
            if (type == typeof(int)) return int.Parse(value);
            if (type == typeof(ulong)) return ulong.Parse(value);
            if (type == typeof(long)) return long.Parse(value);
            if (type == typeof(DateTime)) return DateTime.Parse(value);
            if (type == typeof(TimeSpan)) return TimeSpan.Parse(value);
            throw new InvalidCastException($"{type.Name}: {value}");
        }
    }





}
