using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static MacroLib.Outputs.HID.WinAPI;

namespace MacroLib.Outputs.HID
{
    public static class Mouse
    {
        public static void MoveAbsolute(int x, int y) => Cursor.Position = new Point(x, y);
        public static void MoveRelative(int x, int y)
        {
            var pos = Cursor.Position;
            pos.X += x;
            pos.Y += y;
            Cursor.Position = pos;
        }
        public static void LeftDown() => Command(0, 0, 0, MouseStroke.LEFT_DOWN);
        public static void LeftUp() => Command(0, 0, 0, MouseStroke.LEFT_UP);
        public static void RightDown() => Command(0, 0, 0, MouseStroke.RIGHT_DOWN);
        public static void RightUp() => Command(0, 0, 0, MouseStroke.RIGHT_UP);
        public static void LeftClick()
        {
            LeftDown();
            LeftUp();
        }
        public static void MouseRightClick()
        {
            RightDown();
            RightUp();
        }
        public static void Wheel(int value) => Command(0, 0, value, MouseStroke.WHEEL);
        static void Command(int x, int y, int data, MouseStroke storoke)
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
    }


}
