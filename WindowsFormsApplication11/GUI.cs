using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace WindowsFormsApplication11
{
    /// <summary>
    /// ターゲットウィンドウの操作を行うクラス
    /// できる事：マウス・キーボード・画面キャプチャ
    /// </summary>
    public class GUI : IDisposable
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
        public GUI(string processName)
        {
            proc = Process.GetProcesses().First(_ => _.ProcessName == processName);
        }

        public void Dispose()
        {
            proc.Dispose();
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
