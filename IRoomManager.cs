using System.Collections.Generic;

namespace SynchronousPlugin.KWY
{
    interface IRoomManager
    {
        Dictionary<string, bool> LobbyReadyState { get; }

        bool AddNewUser(string id);
        bool SetReadyState(string id, bool state);

        bool RemoveUser(string id);

        /// <summary>
        /// true: two client sent the ready signals; false : else
        /// </summary>
        /// <returns>{ true if two clients are ready }</returns>
        bool CheckAllReady();
    }
}
