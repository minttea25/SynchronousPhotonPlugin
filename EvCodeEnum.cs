using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronousPlugin.KWY
{
    public enum EvCode : byte
    {
        // for lobby
        LobbyReady = 10,
        ResLobbyReady = 110,

        // for main
        TurnReady = 11,
        SimulEnd = 12,
        GameEnd = 13,


        PlayerSkill1 = 21,
        PlayerSkill2 = 22,
        PlayerSkill3 = 23,

        ResTurnReady = 111,
        ResSimulEnd = 112,
        ResGameEnd = 113,

    }
}
