using System.Collections.Generic;

namespace SynchronousPlugin.KWY
{
    class RoomManager : IRoomManager
    {
        public Dictionary<string, bool> LobbyReadyState { get; private set; } = new Dictionary<string, bool>();

        public bool AddNewUser(string id)
        {
            if (IsFull())
            {
                return false;
            }

            if (LobbyReadyState.ContainsKey(id))
            {
                return false;
            }

            LobbyReadyState.Add(id, false);
            return true;
        }

        public bool RemoveUser(string id)
        {
            return LobbyReadyState.Remove(id);
        }

        public bool CheckAllReady()
        {
            // if numeber of players is only one, return false;
            if (!IsFull())
            {
                return false;
            }

            foreach (bool r in LobbyReadyState.Values)
            {
                if (!r) return false;
            }
            return true;
        }

        public bool SetReadyState(string id, bool state)
        {
            if (!LobbyReadyState.ContainsKey(id))
            {
                return false;
            }

            LobbyReadyState[id] = state;
            return true;
        }

        private bool IsFull()
        {
            return LobbyReadyState.Count == 2;
        }
    }
}
