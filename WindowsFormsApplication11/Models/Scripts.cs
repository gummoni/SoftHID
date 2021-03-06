﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MacroLib.Models
{
    public class Scripts : List<Script>
    {

        public Scripts(string scriptPath)
        {
            var files = Directory.GetFiles(scriptPath);
            foreach (var file in files)
            {
                Add(new Script(file));
            }
        }

        public string[] this[string scriptname]
        {
            get
            {
                return this.FirstOrDefault(_ => _.ScriptName == scriptname)?.GetScriptCode();
            }
        }
    }

    public class Script
    {
        static Regex regComment = new Regex("'.*$");
        public string ScriptName { get; }

        string fullPath;

        public Script(string fullPath)
        {
            this.fullPath = fullPath;
            ScriptName = Path.GetFileNameWithoutExtension(fullPath);
        }

        public string[] GetScriptCode()
        {
            return File.ReadAllLines(fullPath).Select(_=> regComment.Replace(_, "").Trim()).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray();
        }
    }
}
