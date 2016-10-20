using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApplication11
{
    /// <summary>
    /// WurmClient
    /// </summary>
    public class WurmClient : GUI
    {
        public string GetState(string key) => (StateDic.ContainsKey(key)) ? StateDic[key] : "";
        Dictionary<string, string> StateDic = new Dictionary<string, string>();
        WurmSettingData data;
        LogReader log;

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="logPath"></param>
        /// <param name="encoding"></param>
        public WurmClient(WurmSettingData data) : base(data.WindowName)
        {
            this.data = data;
            log = new LogReader(data.LogPath, data.Encoding);
            log.ReadLineRecieved += Log_ReadLineRecieved;
        }

        /// <summary>
        /// 開放処理
        /// </summary>
        public override void Dispose()
        {
            log.ReadLineRecieved -= Log_ReadLineRecieved;
            log.Dispose();
            base.Dispose();
        }

        /// <summary>
        /// 受信解析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Log_ReadLineRecieved(object sender, string e)
        {
            var model = data.PassiveList.FirstOrDefault(_ => e.Contains(_.Keyword));
            if (null != model)
            {
                var split = model.Keyword.Split('.');
                StateDic[split[0]] = split[1];
            }
        }

        /// <summary>
        /// スクリプト実行
        /// </summary>
        bool isPower = false;
        public void Execute(string filename)
        {
            var console = new ObjectConsole<WurmClient>(this);
            var lines = File.ReadAllLines(filename);
            isPower = true;
            foreach (var line in lines)
            {
                if (!isPower) break;
                console.Execute(line);
            }
        }

        /// <summary>
        /// スクリプト中断処理
        /// </summary>
        public void Abort()
        {
            isPower = false;
        }

    }
}
