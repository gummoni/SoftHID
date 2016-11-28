using MacroLib.Outputs.Bitmaps;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using static MacroLib.Inputs.GUI.WinAPI;

namespace MacroLib.Inputs.GUI
{
    /// <summary>
    /// ターゲットウィンドウの操作を行うクラス
    /// できる事：マウス・キーボード・画面キャプチャ
    /// </summary>
    public class Window : IDisposable
    {
        Process proc;
        public IntPtr MainWindowHandle => proc.MainWindowHandle;

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
        public Window(string processName)
        {
            var procs = Process.GetProcesses();
            proc = procs.First(_ => _.ProcessName == processName);
        }

        public virtual void Dispose()
        {
            proc.Dispose();
        }

        /// <summary>
        /// 画面をキャプチャしてBitmapを返す。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns>クライアント領域のBitmap。キャプチャに失敗した場合null。</returns>
        public MatBitmap Snapshot()
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
            return new MatBitmap(img);
        }

        public void Kill() => proc.Kill();
    }
}
