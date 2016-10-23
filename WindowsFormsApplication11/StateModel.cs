using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApplication11
{
    public class StateModel
    {
        public string State { get; set; }
        public List<PassiveModel> Models { get; set; }

        public bool IsActive => Models.FirstOrDefault(_ => _.IsActive == true) != null;

        public int RestTime => Models.Max(_ => _.RestTime);
    }

    public class StateCollection : List<StateModel>
    {
        public static StateCollection Create(PassiveCollection collection)
        {
            var result = new StateCollection();

            foreach (var model in collection)
            {
                var state = model.State;
                var key = result.FirstOrDefault(_ => _.State == state);
                if (null == key)
                {
                    key = new StateModel();
                    key.Models = new List<PassiveModel>();
                    key.State = state;
                    result.Add(key);
                }
                key.Models.Add(model);
            }

            return result;
        }
    }
}
