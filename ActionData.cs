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

        public override string ToString()
        {
            string t = "[";

            foreach (int id in _data.Keys)
            {
                t += $"id: {id} [";
                foreach (object[] o in _data[id])
                {
                    if ((ActionType)(o[1]) == ActionType.Move)
                    {
                        t += $"time: {(int)o[0]}, type: MOVE, dx: {o[2]}, dy: {o[3]}, ex0: {o[4]}, ex1: {o[5]} / ";
                    }
                    else
                    {
                        t += $"time: {(int)o[0]}, type: SKILL, sid: {o[2]}, skill dir: {o[3]}, s_x: {o[4]}, s_y: {o[5]} / ";
                    }

                }
                t += "]";
            }
            t += "]";

            return t;
        }
    }
}
