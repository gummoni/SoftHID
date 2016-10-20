using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication11
{
    public static class Convert
    {
        public static object Parse(Type type, string value)
        {
            if (type == typeof(string)) return value;
            if (type == typeof(byte)) return byte.Parse(value);
            if (type == typeof(sbyte)) return sbyte.Parse(value);
            if (type == typeof(ushort)) return ushort.Parse(value);
            if (type == typeof(short)) return short.Parse(value);
            if (type == typeof(uint)) return uint.Parse(value);
            if (type == typeof(int)) return int.Parse(value);
            if (type == typeof(ulong)) return ulong.Parse(value);
            if (type == typeof(long)) return long.Parse(value);
            if (type == typeof(DateTime)) return DateTime.Parse(value);
            if (type == typeof(TimeSpan)) return TimeSpan.Parse(value);
            throw new InvalidCastException($"{type.Name}: {value}");
        }
    }
}
