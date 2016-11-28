using MacroLib.Inputs.GUI;
using MacroLib.Outputs.HID;
using System;
using System.Threading;
using System.Windows.Forms;
using static MacroLib.Inputs.GUI.WinAPI;

namespace MacroLib
{
    /// <summary>
    /// ソフトHIDコントローラ
    /// 入力
    /// 　Window画面(Process)
    /// 　マウス入力（Hook)
    /// 　キー入力（Hook)
    /// 　画面入力（Snapshot）
    /// 　ログ入力（Reader）
    ///
    /// 出力
    ///　　キー出力
    ///　　マウス出力
    /// 
    /// 処理
    /// 　マクロ処理
    /// 　　トリガーは全てログから
    /// </summary>
    public class Controller
    {
        Window window;

        public Controller(string processName)
        {
            window = new Window(processName);
        }

        public void Sleep(int delay) => Thread.Sleep(delay);
        public void WindowActivate() => SetForegroundWindow(window.MainWindowHandle);
        public void WindowKill() => window.Kill();
        public void KeyPress(string message) => Keyboard.KeyPress(message);
        public void KeyDown(string message) => Keyboard.KeyDown(message);
        public void KeyUp(string message) => Keyboard.KeyUp(message);
        public void MouseMoveAbsolute(int x, int y)
        {
            RECT rect;
            if (!GetWindowRect(window.MainWindowHandle, out rect))
            {
                throw new InvalidOperationException("ウィンドウが見つかりません");
            }
            Mouse.MoveAbsolute(rect.left + x, rect.top + y);
        }
        public void MouseMoveRelative(int x, int y) => Mouse.MoveRelative(x, y);
        public void MouseLeftClick() => Mouse.LeftClick();
        public void MouseRightClick() => Mouse.MouseRightClick();

        public void ShoeMessageBox(string message)
        {
            MessageBox.Show(message);
        }
    }
}
