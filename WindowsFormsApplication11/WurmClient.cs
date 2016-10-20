using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApplication11
{
    /// <summary>
    /// WurmClient
    /// </summary>
    public class WurmClient : GUI
    {
        public string GetState(string key) => (StateDic.ContainsKey(key)) ? StateDic[key] : "";
        Dictionary<string, string> StateDic = new Dictionary<string, string>();
        ObjectConsole<WurmClient> console;
        WurmSettingData data;
        LogReader log;
        Task activeTask;
        bool isPower = false;
        Dictionary<string, string[]> cacheScripts = new Dictionary<string, string[]>();

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="logPath"></param>
        /// <param name="encoding"></param>
        public WurmClient(WurmSettingData data) : base(data.WindowName)
        {
            console = new ObjectConsole<WurmClient>(this);
            this.data = data;
            log = new LogReader(data.LogPath, data.Encoding);
            log.ReadLineRecieved += Log_ReadLineRecieved;
        }

        /// <summary>
        /// 開放処理
        /// </summary>
        public override void Dispose()
        {
            AbortScript();
            log.ReadLineRecieved -= Log_ReadLineRecieved;
            log.Dispose();
            base.Dispose();
        }

        /// <summary>
        /// 受信解析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Log_ReadLineRecieved(object sender, string e)
        {
            var model = data.PassiveList.FirstOrDefault(_ => e.Contains(_.Keyword));
            if (null != model)
            {
                var split = model.State.Split('.');
                StateDic[split[0]] = split[1];
            }
        }

        /// <summary>
        /// スクリプトコマンドないで実行する用
        /// </summary>
        /// <param name="actionScript"></param>
        /// <param name="flagments"></param>
        [Command]
        public void Action(string actionScript, string flagments)
        {
            //スクリプト実行
            if (ParseFlagments(flagments))
            {
                var lines = PreDecode(actionScript + ".txt");
                Execute(lines);
            }
        }

        /// <summary>
        /// 状態フラグ
        /// </summary>
        /// <param name="state"></param>
        /// <param name="flagments"></param>
        [Command]
        public void Flag(string state, string flagments)
        {
            var split = state.Split('.');

            if (ParseFlagments(flagments))
            {
                //フラグON
                StateDic[split[0]] = split[1];
            }
            else
            {
                //フラグOFF
                if (StateDic.ContainsKey(split[0]))
                {
                    StateDic.Remove(split[0]);
                }
            }
        }

        /// <summary>
        /// スクリプト実行
        /// </summary>
        /// <param name="filename"></param>
        [Command]
        public void StartScript(string filename)
        {
            if (null != activeTask)
            {
                var isFinish = (activeTask.IsCompleted || activeTask.IsCanceled || activeTask.IsFaulted);
                if (!isFinish)
                {
                    return;
                }
            }
            activeTask = Task.Run(() =>
            {
                isPower = true;
                var lines = PreDecode(filename);
                while (isPower)
                {
                    Execute(lines);
                    Task.Delay(10);
                }
            });
        }

        /// <summary>
        /// スクリプト中断処理
        /// </summary>
        [Command]
        public void AbortScript()
        {
            isPower = false;
            activeTask?.Wait();
            cacheScripts.Clear();
        }

        /// <summary>
        /// スクリプトファイルを取得する
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        string[] PreDecode(string filename)
        {
            var path = Path.Combine(WurmSettingData.scriptsDir, filename);

            if (!cacheScripts.ContainsKey(path))
            {
                //キャッシュが無い場合
                var lines = File.ReadAllLines(path);
                cacheScripts[path] = lines.Select(_ =>
                {
                    //余分なスペースとコメント行を削除する
                    return Regex.Replace(_.Trim(), "^;", "");
                })
                .Where(_ =>
                {
                    //空行は削除する
                    return !string.IsNullOrEmpty(_);
                }).ToArray();
            }
            return cacheScripts[path];
        }

        /// <summary>
        /// 状態変更
        /// </summary>
        /// <param name="state"></param>
        [Command]
        public void ChangeState(string state)
        {
            var split = state.Split('.');
            StateDic[split[0]] = split[1];
        }

        /// <summary>
        /// スクリプト実行本体
        /// </summary>
        void Execute(string[] lines)
        {
            foreach (var line in lines)
            {
                if (!isPower) break;
                console.Execute(line);
            }
        }

        /// <summary>
        /// フラグ解析
        /// </summary>
        /// <param name="flagments"></param>
        /// <returns></returns>
        bool ParseFlagments(string flagments)
        {
            var arguments = flagments.Trim().Split('|');

            foreach (var flag in arguments)
            {
                string pattern = "^[ \t]*!";
                var isNot = Regex.IsMatch(flag, pattern);
                var _flag = Regex.Replace(flag, pattern, "").Trim();
                var data = _flag.Trim().Split('.').Select(_ => _.Trim()).ToArray();
                if (data.Length != 2) throw new InvalidDataException(flag);

                if (isNot)
                {
                    if (StateDic.ContainsKey(data[0]))
                    {
                        if (StateDic[data[0]] == data[1])
                        {
                            //状態一致
                            return false;
                        }
                    }
                }
                else
                {
                    if (!StateDic.ContainsKey(data[0]))
                    {
                        //状態が存在しない
                        return false;
                    }
                    if (StateDic[data[0]] != data[1])
                    {
                        //状態不一致
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
