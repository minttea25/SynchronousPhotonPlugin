using System.Collections.Generic;

namespace SynchronousPlugin.KWY
{
    class MainGameManager : IMainGameManager
    {
        public uint turnNum = 1;

        public Dictionary<string, ActionData> userActionData { get; private set; }
        public ActionData NowActionData { get; private set; } = new ActionData();

        public MainGameManager()
        {
            userActionData = new Dictionary<string, ActionData>();
            NowActionData = new ActionData();
        }

        public MainGameManager(string id1, string id2)
        {
            userActionData = new Dictionary<string, ActionData>();
            NowActionData = new ActionData();
            userActionData.Add(id1, new ActionData());
            userActionData.Add(id2, new ActionData());
        }

        public void AddUserId(string id)
        {
            userActionData.Add(id, new ActionData());
        }

        /// <summary>
        /// Combine action data
        /// </summary>
        /// <param name="d1">Action data from client A</param>
        /// <param name="d2">Action data from client B</param>
        /// <returns>Combined action data: Dictionary(int, int)</returns>
        public ActionData CombineActionData()
        {
            ActionData combinedAcitionData = new ActionData();

            foreach(string user in userActionData.Keys)
            {
                foreach(int id in userActionData[user].Data.Keys)
                {
                    combinedAcitionData.Data.Add(id, userActionData[user].Data[id]);
                }
            }

            return combinedAcitionData;
        }

        public bool RemoveUser(string id)
        {
            return userActionData.Remove(id);
        }

        public bool CheckAllReady()
        {
            if (NowActionData.Data.Count == 0) return false;
            return true;
        }

        public bool SetActionData(string id, ActionData actionData)
        {
            if (!userActionData.ContainsKey(id))
            {
                return false;
            }

            userActionData[id] = actionData;


            // 두 개의 데이터가 모두 들어와 있으면 simulData 만들기
            bool flag = true;
            foreach (var v in userActionData.Values)
            {
                if (v.Data.Count == 0) flag = false;
            }

            if (flag)
            {
                NowActionData = CombineActionData();
            }

            return true;
        }

        public void ResetData()
        {
            foreach (string k in userActionData.Keys)
            {
                userActionData[k].Data.Clear();
            }
            NowActionData.Data.Clear();
        }
    }
}
