using System.Runtime.InteropServices;

namespace MacroLib.Outputs.HID
{
    static class WinAPI
    {
        [DllImport("user32.dll")]
        extern internal static void SendInput(int nUnputs, ref INPUT pInputs, int cbsize);

        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyA")]
        extern internal static int MapVirtualKey(int wCode, int wMapType);
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct KeyboardInput
    {
        public short VirtualKey;
        public short ScanCode;
        public int Flags;
        public int Time;
        public int ExtraInfo;
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct MouseInput
    {
        public int X;
        public int Y;
        public int Data;
        public int Flags;
        public int Time;
        public int ExtraInfo;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct HardwareInput
    {
        public int Message;
        public short ParamL;
        public short ParamH;
    };

    [StructLayout(LayoutKind.Explicit)]
    internal struct INPUT
    {
        [FieldOffset(0)]
        public int type;

        [FieldOffset(4)]
        public MouseInput Mouse;

        [FieldOffset(4)]
        public KeyboardInput Keyboard;
    };

    enum InputMode
    {
        MOUSE = 0,                          // マウスイベント
        KEYBOARD = 1,                       // キーボードイベント
        HARDWARE = 2,                       // ハードウェアイベント
    }

    enum KeyboardStroke
    {
        KEY_DOWN = 0x0000,
        KEY_UP = 0x0002,
        KEY_EXTENDED_KEY = 0x0001,
    }

    enum MouseStroke
    {
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
        VIRTUALDESK = 0x4000,
        ABSOLUTE = 0x8000,
    }
}
