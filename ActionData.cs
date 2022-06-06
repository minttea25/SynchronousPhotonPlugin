using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronousPlugin
{
    public class ActionData
    {
        Dictionary<int, object[]> _data;

        public Dictionary<int, object[]> Data { get { return _data; } }

        public ActionData()
        {
            _data = new Dictionary<int, object[]>();
        }

        // Serialize 비슷한 method
        public ActionData(Dictionary<int, object[]> data)
        {
            _data = data;
        }
    }
}
