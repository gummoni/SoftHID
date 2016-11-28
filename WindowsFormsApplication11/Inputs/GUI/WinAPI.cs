using System;
using System.Runtime.InteropServices;

namespace MacroLib.Inputs.GUI
{
    internal class WinAPI
    {
        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32", SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32", SetLastError = true)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        //クライアント領域キャプチャ用のメソッドと、戻り値用の構造体
        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public int x;
            public int y;
        }

        [DllImport("user32", SetLastError = true)]
        internal static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        internal static extern int GetClientRect(IntPtr hwnd, out RECT lpRect);
        [DllImport("user32.dll")]
        internal static extern bool ClientToScreen(IntPtr hwnd, out POINT lpPoint);
    }
}
