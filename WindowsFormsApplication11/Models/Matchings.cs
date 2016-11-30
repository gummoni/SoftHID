using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MacroLib.Models
{
    /// <summary>
    /// パターンマッチングの一覧
    /// 　正規表現,実行スクリプト
    /// </summary>
    public class Matchings : List<Matching>
    {
        public event EventHandler OnMatching;

        public Matchings(string filename)
        {
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var text = Regex.Replace(line, "'.*$", "").Trim();
                if (string.IsNullOrEmpty(text)) continue;

                var args = text.Split(',').Select(_ => _.Trim()).ToArray();
                if (2 == args.Length)
                {
                    Add(new Matching(args[0], args[1]));
                }
            }
        }

        public void DoEvents(string line)
        {
            foreach (var matching in this)
            {
                var mat = matching.Match(line);
                if (mat.Success)
                {
                    OnMatching?.Invoke(mat, new MatchingEventArgs(line, mat, matching.Script));
                }
            }
        }
    }

    public class Matching
    {
        Regex reg;
        public string Script { get; }

        public Matching(string pattern, string script)
        {
            reg = new Regex(pattern);
            Script = script;
        }

        public Match Match(string line)
        {
            return reg.Match(line);
        }
    }

    public class MatchingEventArgs : EventArgs
    {
        public string Line { get; }
        public Match Match { get; }
        public string ScriptName { get; }

        public MatchingEventArgs(string line, Match match, string scriptNmae)
        {
            Line = line;
            Match = match;
            ScriptName = scriptNmae;
        }
    }
}
