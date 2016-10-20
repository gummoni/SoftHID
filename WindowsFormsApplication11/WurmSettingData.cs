using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace WindowsFormsApplication11
{
    [DataContract]
    public class WurmSettingData
    {
        [DataMember]
        public string WindowName { get; set; }
        [DataMember]
        public string LogPath { get; set; }
        [DataMember]
        public Encoding Encoding { get; set; } = Encoding.GetEncoding(932);
        [DataMember]
        public LogAnalyzeCollection PassiveList { get; set; } = new LogAnalyzeCollection();     //状態変化

        WurmClient client;

        public WurmSettingData()
        {
            client = new WurmClient(this);
        }


        public void Dispose()
        {
            client.Dispose();
        }

        public string[] GetActiveList() => Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt", SearchOption.TopDirectoryOnly); //ユーザによる実行（格納されているのはスクリプトファイル名）

    }
}
