using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MacroLib.Models
{
    public class Passives : List<Passive>
    {

        public Passives(string passivesPath)
        {
            var files = Directory.GetFiles(passivesPath);
            foreach (var file in files)
            {
                Add(new Passive(file));
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
    public class Passive 
    {
        static Regex regComment = new Regex("'.*$");
        public string ScriptName { get; }

        string fullPath;

        public Passive(string fullPath)
        {
            this.fullPath = fullPath;
            ScriptName = Path.GetFileNameWithoutExtension(fullPath);
        }

        public string[] GetScriptCode()
        {
            return File.ReadAllLines(fullPath).Select(_ => regComment.Replace(_, "").Trim()).Where(_ => !string.IsNullOrWhiteSpace(_)).ToArray();
        }
    }
}

