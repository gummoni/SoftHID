using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
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

    /// <summary>
    /// ユーザーが行うキー・マウス操作をプログラムから行う
    /// </summary>
    public static class HID
    {
        #region "p/invoke"
        [StructLayout(LayoutKind.Sequential)]
        struct KeyboardInput
        {
            public short VirtualKey;
            public short ScanCode;
            public int Flags;
            public int Time;
            public int ExtraInfo;
        };

        [StructLayout(LayoutKind.Sequential)]
        struct MouseInput
        {
            public int X;
            public int Y;
            public int Data;
            public int Flags;
            public int Time;
            public int ExtraInfo;
        };

        [StructLayout(LayoutKind.Explicit)]
        struct INPUT
        {
            [FieldOffset(0)]
            public int type;

            [FieldOffset(4)]
            public MouseInput Mouse;

            [FieldOffset(4)]
            public KeyboardInput Keyboard;
        };

        [DllImport("user32.dll")]
        extern static void SendInput(int nUnputs, ref INPUT pInputs, int cbsize);

        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyA")]
        extern static int MapVirtualKey(int wCode, int wMapType);

        enum InputMode
        {
            MOUSE = 0,                          // マウスイベント
            KEYBOARD = 1,                       // キーボードイベント
        }

        enum MouseStroke
        {
            ABSOLUTE = 0x8000,
            MOVE = 0x0001,
            LEFT_DOWN = 0x0002,
            LEFT_UP = 0x0004,
            RIGHT_DOWN = 0x0008,
            RIGHT_UP = 0x0010,
            MIDDLE_DOWN = 0x0020,
            MIDDLE_UP = 0x0040,
            X_DOWN = 0x0080,
            X_UP = 0x0100,
            WHEEL = 0x0800,
        }

        enum KeyboardStroke
        {
            KEY_DOWN = 0x0000,
            KEY_UP = 0x0002,
            KEY_EXTENDED_KEY = 0x0001,
        }
        #endregion

        #region "keyboard"
        public static void KeyPress(string key)
        {
            Keys keycode;
            if (Enum.TryParse(key, true, out keycode))
            {
                KeyDown((short)keycode);
                KeyUp((short)keycode);
            }
            else
            {
                foreach (var ch in key)
                {
                    if (Enum.TryParse(ch.ToString(), true, out keycode))
                    {
                        KeyDown((short)keycode);
                        KeyUp((short)keycode);
                    }
                    else
                    {
                        var scode = GetSpecialKey(ch);
                        if (0 != scode)
                        {
                            KeyDown((short)Keys.ShiftKey);
                            KeyDown(scode);
                            KeyUp(scode);
                            KeyUp((short)Keys.ShiftKey);
                        }
                        else
                        {
                            KeyDown((short)ch);
                            KeyUp((short)ch);
                        }
                    }
                }
            }
        }
        public static void KeyDown(string key)
        {
            Keys keycode;
            if (Enum.TryParse(key, true, out keycode))
            {
                KeyDown((short)keycode);
            }
            else
            {
                foreach (var ch in key)
                {
                    if (Enum.TryParse(ch.ToString(), true, out keycode))
                    {
                        KeyDown((short)keycode);
                    }
                }
            }
        }
        public static void KeyUp(string key)
        {
            Keys keycode;
            if (Enum.TryParse(key, true, out keycode))
            {
                KeyUp((short)keycode);
            }
            else
            {
                foreach (var ch in key)
                {
                    if (Enum.TryParse(ch.ToString(), true, out keycode))
                    {
                        KeyUp((short)keycode);
                    }
                }
            }
        }
        static short GetSpecialKey(char ch)
        {
            if ('A' <= ch && ch <= 'Z')
            {
                return (short)ch;
            }

            switch (ch)
            {
                case '!': return (short)'1';
                case '"': return (short)'2';
                case '#': return (short)'3';
                case '$': return (short)'4';
                case '%': return (short)'5';
                case '&': return (short)'6';
                case '\'': return (short)'7';
                case '(': return (short)'8';
                case ')': return (short)'9';
                case '=': return (short)'-';
                case '~': return (short)'^';
                case '|': return (short)'\\';
                case '`': return (short)'@';
                case '{': return (short)'[';
                case '+': return (short)';';
                case '*': return (short)':';
                case '}': return (short)']';
                case '<': return (short)',';
                case '>': return (short)'.';
                case '?': return (short)'/';
                default: return 0;
            }
        }
        static void KeyDown(short key) => KeyCommand(key, KeyboardStroke.KEY_EXTENDED_KEY | KeyboardStroke.KEY_DOWN);
        static void KeyUp(short key) => KeyCommand(key, KeyboardStroke.KEY_EXTENDED_KEY | KeyboardStroke.KEY_UP);
        static void KeyCommand(short key, KeyboardStroke storoke)
        {
            var inp = new INPUT();
            inp.type = (int)InputMode.KEYBOARD;
            inp.Keyboard.VirtualKey = key;
            inp.Keyboard.ScanCode = (short)MapVirtualKey(key, 0);
            inp.Keyboard.Flags = (int)storoke;
            inp.Keyboard.ExtraInfo = 0;
            inp.Keyboard.Time = 0;
            SendInput(1, ref inp, Marshal.SizeOf(inp));
        }
        #endregion

        #region "mouse"
        public static void MouseMoveAbsolute(int x, int y) => MouseCommand(x, y, 0, MouseStroke.MOVE | MouseStroke.ABSOLUTE);
        public static void MouseMoveRelative(int x, int y) => MouseCommand(x, y, 0, MouseStroke.MOVE);
        public static void MouseLeftDown() => MouseCommand(0, 0, 0, MouseStroke.LEFT_DOWN);
        public static void MouseLeftUp() => MouseCommand(0, 0, 0, MouseStroke.LEFT_UP);
        public static void MouseRightDown() => MouseCommand(0, 0, 0, MouseStroke.RIGHT_DOWN);
        public static void MouseRightUp() => MouseCommand(0, 0, 0, MouseStroke.RIGHT_UP);
        public static void MouseLeftClick()
        {
            MouseLeftDown();
            MouseLeftUp();
        }
        public static void MouseRightClick()
        {
            MouseRightDown();
            MouseRightUp();
        }
        public static void MouseWheel(int value) => MouseCommand(0, 0, value, MouseStroke.WHEEL);
        static void MouseCommand(int x, int y, int data, MouseStroke storoke)
        {
            var inp = new INPUT();
            inp.type = (int)InputMode.MOUSE;
            inp.Mouse.X = x;
            inp.Mouse.Y = y;
            inp.Mouse.Data = data;
            inp.Mouse.Flags = (int)storoke;
            inp.Mouse.ExtraInfo = 0;
            inp.Mouse.Time = 0;
            SendInput(1, ref inp, Marshal.SizeOf(inp));
        }
        #endregion
    }

    /// <summary>
    /// ターゲットウィンドウの操作を行うクラス
    /// できる事：マウス・キーボード・画面キャプチャ
    /// </summary>
    public class WindowController
    {
        #region "p/invoke"
        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32", SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        //クライアント領域キャプチャ用のメソッドと、戻り値用の構造体
        [StructLayout(LayoutKind.Sequential)]
        struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public int x;
            public int y;
        }

        [DllImport("user32", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        static extern int GetClientRect(IntPtr hwnd, out RECT lpRect);
        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hwnd, out POINT lpPoint);
        #endregion

        Process proc;

        /// <summary>
        /// プロセスが起動しているか調べる
        /// </summary>
        /// <param name="processName">調べるプロセス名(例:taskmgr)</param>
        /// <returns>True=起動している, False＝起動していない</returns>
        public static bool IsProcessLaunch(string processName) => null != Process.GetProcesses().FirstOrDefault(_ => _.ProcessName == processName);

        /// <summary>
        /// ターゲットウィンドウを取得する
        /// </summary>
        /// <param name="processName"></param>
        public WindowController(string processName)
        {
            proc = Process.GetProcesses().First(_ => _.ProcessName == processName);
        }

        /// <summary>
        /// 画面をキャプチャしてBitmapを返す。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns>クライアント領域のBitmap。キャプチャに失敗した場合null。</returns>
        public Bitmap Snapshot()
        {
            var rect = new RECT();
            if (!GetWindowRect(proc.MainWindowHandle, out rect))
            {
                //キャプチャ失敗
                return null;
            }
            var size = new Size(rect.right - rect.left, rect.bottom - rect.top);
            if (size.Width <= 0 || size.Height <= 0)
            {
                //キャプチャ失敗
                return null;
            }
            var img = new Bitmap(size.Width, size.Height);
            var pt = new POINT { x = rect.left, y = rect.top };
            ClientToScreen(proc.MainWindowHandle, out pt);
            using (var g = Graphics.FromImage(img))
            {
                g.CopyFromScreen(pt.x, pt.y, 0, 0, img.Size);
            }
            return img;
        }

        public void Sleep(int delay) => Thread.Sleep(delay);
        public void WindowActivate() => SetForegroundWindow(proc.MainWindowHandle);
        public void WindowKill() => proc.Kill();
        public void KeyPress(string message) => HID.KeyPress(message);
        public void KeyDown(string message) => HID.KeyDown(message);
        public void KeyUp(string message) => HID.KeyUp(message);
        public void MouseMoveAbsolute(int x, int y)
        {
            RECT rect;
            if (!GetWindowRect(proc.MainWindowHandle, out rect))
            {
                throw new InvalidOperationException("ウィンドウが見つかりません");
            }
            HID.MouseMoveAbsolute(rect.left + x, rect.top + y);
        }
        public void MouseMoveRelative(int x, int y) => HID.MouseMoveRelative(x, y);
        public void MouseLeftClick() => HID.MouseLeftClick();
        public void MouseRightClick() => HID.MouseRightClick();
    }
}
