using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication11
{
    public class PassiveCollection : ObservableCollection<PassiveModel>
    {
        Regex comment = new Regex(";.*$");
        public void Append(string[] lines)
        {
            foreach (var line in lines)
            {
                var text = comment.Replace(line, "").Trim();
                var splits = text.Split(',');
                if (3 != splits.Length) continue;

                var rows = splits.Select(_ => _.Trim()).ToArray();
                Add(new PassiveModel(rows[0], rows[1], rows[2]));
            }
        }

        public string[] Check(string message) => this.Where(_ => _.Check(message)).Select(_=>_.State).ToArray();
    }
}
