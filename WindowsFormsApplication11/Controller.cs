using MacroLib.Inputs.GUI;
using MacroLib.Outputs.HID;
using MacroLib.Models;
using System;
using System.Threading;
using System.Windows.Forms;
using static MacroLib.Inputs.GUI.WinAPI;
using MacroLib.Outputs.Bitmaps;
using System.Collections.Generic;
using System.Drawing;

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
        Dictionary<string, Point> positions = new Dictionary<string, Point>();
        Window window;

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="processName"></param>
        public Controller(string processName)
        {
            window = new Window(processName);
        }

        [Command("ウェイト処理")]
        public void Sleep(int milliseconds) => Thread.Sleep(milliseconds);

        [Command("ウィンドウをアクティブ化します")]
        public void WindowActivate() => SetForegroundWindow(window.MainWindowHandle);

        [Command("ウィンドウを閉じます")]
        public void WindowKill() => window.Kill();

        [Command("キー押下(複数文字OK)")]
        public void KeyPress(string keys) => Keyboard.KeyPress(keys);

        [Command("キー押す(複数文字OK)")]
        public void KeyDown(string keys) => Keyboard.KeyDown(keys);

        [Command("キー離す(複数文字OK)")]
        public void KeyUp(string keys) => Keyboard.KeyUp(keys);

        [Command("マウス位置のウィンドウ内絶対値移動")]
        public void MouseMoveAbsolute(int x, int y)
        {
            RECT rect;
            if (!GetWindowRect(window.MainWindowHandle, out rect))
            {
                throw new InvalidOperationException("ウィンドウが見つかりません");
            }
            Mouse.MoveAbsolute(rect.left + x, rect.top + y);
        }

        [Command("マウス位置の相対値移動")]
        public void MouseMoveRelative(int dx, int dy) => Mouse.MoveRelative(dx, dy);

        [Command("マウス左クリック")]
        public void MouseLeftClick() => Mouse.LeftClick();

        [Command("マウス右クリック")]
        public void MouseRightClick() => Mouse.MouseRightClick();

        [Command("ポップアップ表示")]
        public void Popup(string message)
        {
            MessageBox.Show(message);
        }

        [Command("カーソル位置を記録する")]
        public void PositionSave(string posName)
        {
            positions[posName] = Cursor.Position;
        }

        [Command("カーソル位置を復元する")]
        public void PositionLoad(string posName)
        {
            Cursor.Position = positions[posName];
        }

        /// <summary>
        /// 画像キャプチャ
        /// </summary>
        /// <returns></returns>
        public MatBitmap Snapshot() => window.Snapshot();
    }
}
