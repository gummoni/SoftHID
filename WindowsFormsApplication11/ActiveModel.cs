using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication11
{
    [DataContract]
    public class ActiveModel
    {
        [DataMember]
        public bool IsActive { get; set; } = false;
        [DataMember]
        public EdgeType Edge { get; set; } = EdgeType.Change;
        [DataMember]
        public string Expression { get; set; } = "";
        [DataMember]
        public string StartMacro { get; set; } = "";
    }

    public class ActiveCollection : ObservableCollection<ActiveModel>
    {
    }

    public enum EdgeType
    {
        Change,     //条件が一致かつステータス変化時に実行します
        Timeout,    //条件が一致かつタイムアウトイベント時に実行します
    }
}
