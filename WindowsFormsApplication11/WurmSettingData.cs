using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace WindowsFormsApplication11
{
    [DataContract]
    public class WurmSettingData
    {
        #region "property"
        [DataMember]
        public string WindowName { get; set; }
        [DataMember]
        public string LogPath { get; set; }
        [DataMember]
        public Encoding Encoding { get; set; } = Encoding.GetEncoding(932);
        [DataMember]
        public LogAnalyzeCollection PassiveList { get; set; } = new LogAnalyzeCollection();     //状態変化
        #endregion
        #region "public"
        /// <summary>
        /// アクティブスクリプト取得
        /// </summary>
        /// <returns></returns>
        public string[] GetActiveList() => Directory.GetFiles(scriptsDir, "*.txt", SearchOption.TopDirectoryOnly); //ユーザによる実行（格納されているのはスクリプトファイル名）
        #endregion
        #region "setting"
        internal static string scriptsDir => Path.Combine(Directory.GetCurrentDirectory(), "scripts");
        static readonly string settingPath = "setting.txt";
        public static WurmSettingData Load()
        {
            if (!Directory.Exists(scriptsDir))
            {
                Directory.CreateDirectory(scriptsDir);
            }

            var json = (File.Exists(settingPath)) ? File.ReadAllText(settingPath) : "";
            var model = Json.Parse<WurmSettingData>(json);
            return (model == null) ? new WurmSettingData() : model;
        }
        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            var json = Json.ToString(this);
            File.WriteAllText(settingPath, json);
        }
        /// <summary>
        /// クライアント作成
        /// </summary>
        /// <returns></returns>
        public WurmClient Create() => new WurmClient(this);
        #endregion
    }
}
