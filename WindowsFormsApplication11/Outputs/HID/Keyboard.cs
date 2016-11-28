using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static MacroLib.Outputs.HID.WinAPI;

namespace MacroLib.Outputs.HID
{
    /// <summary>
    /// ユーザーが行うキー・マウス操作をプログラムから行う
    /// </summary>
    public static class Keyboard
    {

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
    }
}
