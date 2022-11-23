using Photon.Hive.Plugin;
using SynchronousPlugin.KWY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronousPlugin
{
    public enum TICK_RESULT
    {
        DRAW = 1,
        MASTER_WIN = 2,
        CLIENT_WIN = 3
    };

    class Session
    {
        public int key { get; private set; }
        public string gameId { get; private set; }
        public string masterId { get; private set; }
        public string clientId { get; private set; }
        public MainGameManager mainGameManager { get; private set; }

        private string win;
        private string lose;
        private bool draw;

        public Session(int key, string gameId, string masterId, string clientId, MainGameManager mainGameManager)
        {
            this.key = key;
            this.gameId = gameId;
            this.masterId = masterId;
            this.clientId = clientId;
            this.mainGameManager = mainGameManager;
        }

        public void SetResult(bool isMasterWinner)
        {
            if (isMasterWinner)
            {
                this.win = masterId;
                this.lose = clientId;
            }
            else
            {
                this.win = clientId;
                this.lose = masterId;
            }
        }

        public void SetReultDraw()
        {
            this.draw = true;
        }

        public void WrtieLog()
        {
            // empty
            ;
        }
    }

    class ManagerHandler
    {
        public const int INVALID_ROOM = 0;

        private object _lock = new object();
        private int locked_id = 1;

        private readonly Dictionary<int, Session> managers = new Dictionary<int, Session>();
        private readonly Dictionary<string, int> userIdRoom = new Dictionary<string, int>();
        private readonly Dictionary<string, int> gameIdRoom = new Dictionary<string, int>();

        public int CreateNewRoom(string gameId, string masterId, string clientId)
        {
            /*uint id = GetNewId();
            managers.Add(id, new Session(id, gameId, masterId, clientId, new MainGameManager(masterId, clientId)));

            if (gameIdRoom.ContainsKey(gameId))
            {
                gameIdRoom.Remove(gameId);
            }
            gameIdRoom.Add(gameId, id);

            if (userIdRoom.ContainsKey(masterId))
            {
                userIdRoom.Remove(masterId);
            }
            userIdRoom.Add(masterId, id);

            if (userIdRoom.ContainsKey(clientId))
            {
                userIdRoom.Remove(clientId);
            }
            userIdRoom.Add(clientId, id);

            return id;*/



            try
            {
                int id = GetNewId();
                managers.Add(id, new Session(id, gameId, masterId, clientId, new MainGameManager(masterId, clientId)));

                if (gameIdRoom.ContainsKey(gameId))
                {
                    gameIdRoom.Remove(gameId);
                }
                gameIdRoom.Add(gameId, id);

                if (userIdRoom.ContainsKey(masterId))
                {
                    userIdRoom.Remove(masterId);
                }
                userIdRoom.Add(masterId, id);

                if (userIdRoom.ContainsKey(clientId))
                {
                    userIdRoom.Remove(clientId);
                }
                userIdRoom.Add(clientId, id);

                return id;
            }
            catch (Exception)
            {
                return INVALID_ROOM;
            }

        }

        public bool RemoveRoom(int id)
        {
            if (managers.TryGetValue(id, out Session value))
            {
                managers.Remove(id);
                return true;
            }
            return false;
        }

        public int GetRoomIdFromGameId(string gameId)
        {
            if (gameIdRoom.TryGetValue(gameId, out int id))
            {
                return id;
            }
            else
            {
                return INVALID_ROOM;
            }
        }

        public int GetRoomIdFromUserId(string userId)
        {
            if (userIdRoom.TryGetValue(userId, out int id))
            {
                return id;
            }
            else
            {
                return INVALID_ROOM;
            }
        }

        public Session GetManager(int id)
        {
            if (managers.TryGetValue(id, out Session value))
            {
                return value;
            }
            return null;
        }

        private int GetNewId()
        {
            int t;
            lock (_lock)
            {
                t = locked_id;
                locked_id++;
                if (locked_id <= 0)
                {
                    locked_id = 1;
                }
            }
            return t;
        }

        private bool SubId()
        {
            bool b = false;
            lock (_lock)
            {
                if (locked_id > 0)
                {
                    locked_id--;
                    b = true;
                }
            }
            return b;
        }
    }
}
