using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MacroLib.Models
{
    public static class AttributeExtensions
    {
        public static T GetCustomAttribute<T>(this MethodInfo self)
        {
            return (T)self.GetCustomAttributes(true).FirstOrDefault(_ => _.GetType() == typeof(T));
        }
    }

    /// <summary>
    /// 関数一覧
    /// </summary>
    public class Methods : List<Method>
    {
        public void Add(MethodInfo[] minfos)
        {
            foreach (var minfo in minfos)
            {
                var attr = minfo.GetCustomAttribute<CommandAttribute>();
                if (null == attr) continue;
                var command = minfo.Name;
                var comment = attr.Message;
                var parameters = minfo.GetParameters();
                var usage = string.Join(", ", minfo.GetParameters().Select(_ => $"[{_.Name}]"));
                usage = (string.Empty == usage) ? command + " <引数なし>" : command + ", " + usage;
                Add(new Method(command, comment, usage));
            }
        }
    }

    /// <summary>
    /// 関数
    /// </summary>
    public class Method
    {
        public string Command { get; }
        public string Comment { get; }
        public string Usage { get; }

        public Method(string command, string comment, string usage)
        {
            Command = command;
            Comment = comment;
            Usage = usage;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {
        public string Message { get; }
        public CommandAttribute(string message)
        {
            Message = message;
        }
    }

}
