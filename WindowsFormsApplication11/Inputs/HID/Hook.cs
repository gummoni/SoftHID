using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace MacroLib.Inputs.HID
{
    public static class Hook
    {
        static GlobalHooker hooker = new GlobalHooker();
        public static MouseHookListener MouseListener = new MouseHookListener(hooker);
        public static KeyboardHookListener KeyListener = new KeyboardHookListener(hooker);
    }
}
