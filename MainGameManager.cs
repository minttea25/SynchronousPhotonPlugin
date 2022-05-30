using System.Collections.Generic;

namespace SynchronousPlugin.KWY
{
    class MainGameManager : IMainGameManager
    {
        public Dictionary<string, Dictionary<int, string>> ActionData { get; private set; } = new Dictionary<string, Dictionary<int, string>>();
        public Dictionary<int, string> NowActionData { get; private set; } = new Dictionary<int, string>();
        public MainGameManager(string id1, string id2)
        {
            ActionData.Add(id1, new Dictionary<int, string>());
            ActionData.Add(id2, new Dictionary<int, string>());
        }

        /// <summary>
        /// Combine action data
        /// </summary>
        /// <param name="d1">Action data from client A</param>
        /// <param name="d2">Action data from client B</param>
        /// <returns>Combined action data: Dictionary(int, int)</returns>
        public Dictionary<int, string> CombineActionData()
        {
            Dictionary<int, string> combinedAcitionData = new Dictionary<int, string>();

            foreach (var d in ActionData.Values)
            {
                // 두 개 데이터 합치기
            }

            return combinedAcitionData;
        }

        public bool RemoveUser(string id)
        {
            return ActionData.Remove(id);
        }

        public bool CheckAllReady()
        {
            if (NowActionData.Count == 0) return false;
            return true;
        }

        public bool SetActionData(string id, Dictionary<int, string> actionData)
        {
            if (!ActionData.ContainsKey(id))
            {
                return false;
            }

            ActionData[id] = actionData;


            // 두 개의 데이터가 모두 들어와 있으면 simulData 만들기
            bool flag = true;
            foreach (var v in ActionData.Values)
            {
                if (v.Count == 0) flag = false;
            }

            if (flag)
            {
                NowActionData = CombineActionData();
            }

            return true;
        }

        public void ResetData()
        {
            foreach (string k in ActionData.Keys)
            {
                ActionData[k].Clear();
            }
            NowActionData.Clear();
        }
    }
}
