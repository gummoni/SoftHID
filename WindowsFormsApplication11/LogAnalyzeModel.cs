using System.Runtime.Serialization;

namespace WindowsFormsApplication11
{
    [DataContract]
    public class LogAnalyzeModel
    {
        [DataMember]
        public string Keyword { get; set; }
        [DataMember]
        public string State { get; set; }

        public LogAnalyzeModel()
        {
        }

        public LogAnalyzeModel(string keyword, string state)
        {
            Keyword = keyword;
            State = state;
        }
    }
}
