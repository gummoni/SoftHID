using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WindowsFormsApplication11
{
    /// <summary>
    /// スクリプトからAPIを呼び出す
    /// スクリプトフォーマット：
    /// 　｛Command｝｛Parameters｝　←コマンドとパラメータ間はスペース区切り
    /// 　パラメータ間はコンマ区切り
    /// </summary>
    /// <typeparam name="MODEL"></typeparam>
    public class ObjectConsole<MODEL>
    {
        MODEL obj;
        MethodInfo[] GetMethods() => typeof(MODEL).GetMethods();

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="model"></param>
        public ObjectConsole(MODEL model)
        {
            obj = model;
        }

        /// <summary>
        /// 実行処理(1行単位)
        /// </summary>
        /// <param name="line"></param>
        public void Execute(string line)
        {
            line = line.Trim();

            var idx = line.IndexOf(' ');
            if (0 > idx)
            {
                Execute(line, new string[] { });
            }
            else
            {
                var command = line.Substring(0, idx).Trim();
                var arguments = line.Substring(idx, line.Length - idx).Trim();
                var parameters = arguments.Split(',').Select(_ => _.Trim()).ToArray();
                Execute(command, (string.IsNullOrEmpty(arguments)) ? new string[] { } : parameters);
            }
        }

        /// <summary>
        /// 実行処理(文字列パラメータ単位)
        /// </summary>
        /// <param name="command"></param>
        /// <param name="arguments"></param>
        object Execute(string command, string[] arguments)
        {
            var method = typeof(MODEL).GetMethod(command, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (method == null)
            {
                throw new Exception($"メソッド{command}が見つかりません");
            }

            var margs = method.GetParameters();
            if (arguments.Length != margs.Length)
            {
                throw new Exception("引数の数が合いません");
            }

            //引数変換
            var parameters = new object[arguments.Length];
            for (var idx = 0; idx < parameters.Length; idx++)
            {
                parameters[idx] = Convert.Parse(margs[idx].ParameterType, arguments[idx]);
            }

            //実行
            return method.Invoke(obj, parameters);
        }

        /// <summary>
        /// コマンド一覧出力
        /// </summary>
        /// <returns></returns>
        public string[] Help()
        {
            var spc = " ";
            var spt = ", ";
            var list = new List<string>();
            return typeof(MODEL)
                .GetMethods()
                .Where(_ => null != _.GetCustomAttribute<CommandAttribute>())
                .Select(_ => $"{_.ReturnType.Name} {_.Name}({string.Join(spt, _.GetParameters().Select(__ => __.ParameterType + spc + __.Name))})")
                .ToArray();
        }
    }

    public class CommandAttribute : Attribute
    {
    }
}
