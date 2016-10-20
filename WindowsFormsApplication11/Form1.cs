using System;
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

            var controller = new WindowController("notepad");
            controller.WindowActivate();
            controller.KeyPress("!!!!!hello World!\r\n");
            controller.MouseMoveAbsolute(100, 100);
            controller.MouseRightClick();
        }
    }



}
