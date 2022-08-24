using Photon.Hive.Plugin;
using Photon;
using System;
using System.Collections.Generic;

namespace SynchronousPlugin.KWY
{
    public class SynchronousPlugin : PluginBase
    {
        public override string Name => "SynchronousPlugin";
        public override string Version => base.Version;
        public override bool IsPersistent => base.IsPersistent;

        #region Added Properties

        private RoomManager roomManager = new RoomManager();
        private MainGameManager gameManager = new MainGameManager();

        #endregion

        public override void OnCreateGame(ICreateGameCallInfo info)
        {
            PluginHost.LogInfo($"OnCreateGame {info.Request.GameId} by user {info.UserId}");

            TestProperties();

            PluginHost.LogInfo($"##### {roomManager.LobbyReadyState}");
            PluginHost.LogInfo($"##### size: {roomManager.LobbyReadyState.Keys.Count}");

            if (roomManager.AddNewUser(info.UserId))
            {
                PluginHost.LogInfo($"### user {info.UserId} is added in Room Manager");
            }
            else
            {
                PluginHost.LogError($"### Can not add user {info.UserId} in Room Manager.");
            }

            foreach (string i in roomManager.LobbyReadyState.Keys)
            {
                bool a;
                roomManager.LobbyReadyState.TryGetValue(i, out a);
                PluginHost.LogInfo($"##### {i}, {a}");
            }



            /*var data = new System.Collections.Generic.Dictionary<byte, object>()
            { { 3, "needed data"} };
            BroadcastEvent(3, data);
            PluginHost.BroadcastEvent(ReciverGroup.All, 0, 0, 3, data, CacheOperations.DoNotCache);*/

            /*var errorData = new System.Collections.Generic.Dictionary<byte, object>()
            { { 1, "error1"}, { 2, "error2"} };

            info.Fail("error msg", errorData);*/

            info.Continue(); // same as base.OnCreateGame(info);

            // 일회용 타이머
            //PluginHost.CreateOneTimeTimer(
            //   info, () => { PluginHost.LogInfo("### 시간 경과"); }, 3000); // ms

            // 반복 타이머
            //PluginHost.CreateTimer(
            //    () => { PluginHost.LogInfo("### 시간 경과"); }, 3000, 2000); // ms / 3초 후 첫번째 실행 이우 2초 간격으로 반복 실행
        }

        void TestProperties()
        {
            PluginHost.LogInfo($"### AppVersion {AppVersion}");
            PluginHost.LogInfo($"### AppId {AppId}");
            PluginHost.LogInfo($"### Region {Region}");
            PluginHost.LogInfo($"### Cloud {Cloud}");
            PluginHost.LogInfo($"### Environment {EnvironmentVerion}");
            PluginHost.LogInfo($"### Name {Name}");
            PluginHost.LogInfo($"### Version {Version}");
            PluginHost.LogInfo($"### IsPersistent {IsPersistent}");
        }

        public override void BeforeCloseGame(IBeforeCloseGameCallInfo info)
        {
            PluginHost.LogInfo($"### BeforeCloseGame by user {info.UserId}");
            base.BeforeCloseGame(info);
        }

        public override void BeforeJoin(IBeforeJoinGameCallInfo info)
        {
            PluginHost.LogInfo($"### BeforeJoin {info.Request.GameId} by user {info.UserId}");
            base.BeforeJoin(info);
        }

        public override void BeforeSetProperties(IBeforeSetPropertiesCallInfo info)
        {
            PluginHost.LogInfo($"### BeforeSetProperties {info.Request.Properties.Keys} by user {info.UserId}");
            base.BeforeSetProperties(info);
        }

        public override void OnCloseGame(ICloseGameCallInfo info)
        {
            PluginHost.LogInfo($"### OnCloseGame by user {info.UserId}");
            base.OnCloseGame(info);
        }

        public override void OnJoin(IJoinGameCallInfo info)
        {
            PluginHost.LogInfo($"### OnJoin {info.Request.GameId} by user {info.UserId}");

            if (roomManager.AddNewUser(info.UserId))
            {
                PluginHost.LogInfo($"### user {info.UserId} is added in Room Manager");
            }
            else
            {
                PluginHost.LogError($"### Can not add user {info.UserId} in Room Manager.");
            }

            base.OnJoin(info);
        }

        public override void OnLeave(ILeaveGameCallInfo info)
        {
            PluginHost.LogInfo($"### OnLeave by user {info.UserId}");

            if (roomManager.RemoveUser(info.UserId))
            {
                PluginHost.LogInfo($"### User {info.UserId} is removed in Room Manager");
            }
            else
            {
                PluginHost.LogError($"### There is no user, User {info.UserId}: Failed to remove user in Room Manager");
            }

            base.OnLeave(info);
        }

        public override void OnRaiseEvent(IRaiseEventCallInfo info)
        {
            PluginHost.LogInfo($"### OnRaiseEvent {info.Request.Data} by user {info.UserId}");

            PluginHost.LogInfo($"info.Request");
            PluginHost.LogInfo($"### EventCode {info.Request.EvCode}");
            PluginHost.LogInfo($"### Actors {info.Request.Actors}");
            PluginHost.LogInfo($"### GameId {info.Request.GameId}");
            PluginHost.LogInfo($"### Group {info.Request.Group}");
            PluginHost.LogInfo($"### HttpForward {info.Request.HttpForward}");
            PluginHost.LogInfo($"### ReceiverGroup {info.Request.ReceiverGroup}");
            PluginHost.LogInfo($"### WebFlags {info.Request.WebFlags}");
            PluginHost.LogInfo($"### OperationCode {info.Request.OperationCode}");
            PluginHost.LogInfo($"### Parameters Keys {info.Request.Parameters.Keys.GetEnumerator()}");
            var e = info.Request.Parameters.Keys.GetEnumerator();
            while (e.MoveNext())
            {
                PluginHost.LogInfo($"### {e.Current}");
            }
            PluginHost.LogInfo($"### Parameters Values {info.Request.Parameters.Values.GetEnumerator()}");
            var e2 = info.Request.Parameters.Values.GetEnumerator();
            while (e2.MoveNext())
            {
                PluginHost.LogInfo($"### {e2.Current}");
            }
            PluginHost.LogInfo($"### Cache {info.Request.Cache}");
            PluginHost.LogInfo($"### CacheSliceIndex {info.Request.CacheSliceIndex}");
            PluginHost.LogInfo($"### ----------------------------------------------");

            PluginHost.LogInfo($"### Status {info.Status}");
            PluginHost.LogInfo($"### Nickname {info.Nickname}");
            PluginHost.LogInfo($"### UserId {info.UserId}");

            PluginHost.LogInfo($"### ActorNr {info.ActorNr}");
            PluginHost.LogInfo($"### AuthCookie {info.AuthCookie}");
            PluginHost.LogInfo($"### AuthCookie {info.Request.Data.ToString()}");

            try
            {
                if (info.Request.Data is object[])
                {
                    foreach (object o in (object[])info.Request.Data)
                    {
                        if (o != null)
                            PluginHost.LogInfo($"### data: {o.ToString()}");
                    }
                }
                else
                {
                    PluginHost.LogInfo($"### data: {info.Request.Data}");
                }


            }
            catch (Exception) { }

            switch (info.Request.EvCode)
            {
                case (byte)EvCode.LobbyReady:
                    RaiseEventCallBackClasses.EventLobbyReady(info, roomManager, gameManager, PluginHost);
                    break;
                case (byte)EvCode.TurnReady:
                    RaiseEventCallBackClasses.EventTurnReady(info, gameManager, PluginHost);
                    break;
                case (byte)EvCode.SimulEnd:
                    RaiseEventCallBackClasses.EventSimulEnd(info, gameManager, PluginHost);
                    break;
                case (byte)EvCode.GameEnd:
                    RaiseEventCallBackClasses.EventGameEnd(info, gameManager, PluginHost);
                    break;
                case 100:
                    info.Request.Data = RaiseEventCallBackClasses.Event100(info, PluginHost);
                    break;
                case 101:
                    info.Request.Data = RaiseEventCallBackClasses.Event101(info, PluginHost);
                    break;
                case 200:
                    break;
                case 201:
                    break;

            }


            base.OnRaiseEvent(info);
        }

        public override void OnSetProperties(ISetPropertiesCallInfo info)
        {
            PluginHost.LogInfo($"### OnSetProperties {info.Request.Properties.Keys} by user {info.UserId}");
            base.OnSetProperties(info);
        }

        protected override void OnChangeMasterClientId(int oldId, int newId)
        {
            PluginHost.LogInfo($"### OnChangeMasterClientId oldId {oldId}, new Id {newId}");
            base.OnChangeMasterClientId(oldId, newId);
        }
    }

    class RaiseEventCallBackClasses : PluginBase
    {
        public static void EventLobbyReady(IRaiseEventCallInfo info, RoomManager roomManager, MainGameManager gameManager, IPluginHost host)
        {
            info.Request.EvCode = (byte)EvCode.ResLobbyReady;

            var data = (object[])info.Request.Data;

            bool ok = roomManager.SetReadyState(info.UserId, (bool)data[0]);

            bool newState = false;
            if (ok)
            {
                newState = roomManager.LobbyReadyState[info.UserId];
            }
            bool startGame = roomManager.CheckAllReady();

            info.Request.Data = new object[] { info.UserId, ok, newState, startGame };

            if (startGame)
            {
                try
                {
                    string[] ids = new string[2];
                    roomManager.LobbyReadyState.Keys.CopyTo(ids, 0);
                    gameManager.AddUserId(ids[0]);
                    gameManager.AddUserId(ids[1]);

                    host.LogInfo($"### MainGameManager instant is created with {ids[0]}, {ids[1]}");
                }
                catch (Exception e)
                {
                    host.LogError(e.Message);
                }

            }


            host.LogInfo($"### Evcode: {info.Request.EvCode}, Data: {info.UserId}, {ok}, {newState}, {startGame}");
        }

        public static void EventTurnReady(IRaiseEventCallInfo info, MainGameManager gameManager, IPluginHost host)
        {
            info.Request.EvCode = (byte)EvCode.ResTurnReady;

            ActionData data;

            if (info.Request.Data is Dictionary<int, object[]> dictionary)
            {
                data = new ActionData(dictionary);
            }
            else
            {
                host.LogInfo($"### Data is not ActionData!!!!!!!!!!!!!!!!!!!!!!!!");
                return;
            }

            bool ok = gameManager.SetActionData(info.UserId, data);
            bool startSimul = gameManager.CheckAllReady();

            if (startSimul)
            {
                ActionData newData = gameManager.NowActionData;

                info.Request.Data = new object[]
                {
                    info.UserId, ok, startSimul, newData.Data
                };

                host.LogInfo($"### Evcode: {info.Request.EvCode}, Data: {info.UserId}, {ok}, {startSimul}, {newData}");
            }
            else
            {
                info.Request.Data = new object[]
                {
                    info.UserId, ok, startSimul
                };

                host.LogInfo($"### Evcode: {info.Request.EvCode}, Data: {info.UserId}, {ok}, {startSimul}");
            }


        }

        public static void EventSimulEnd(IRaiseEventCallInfo info, MainGameManager gameManager, IPluginHost host)
        {
            info.Request.EvCode = (byte)EvCode.ResSimulEnd;
            gameManager.ResetData(); // actionData 리셋
        }

        public static void EventGameEnd(IRaiseEventCallInfo info, MainGameManager gameManager, IPluginHost host)
        {
            info.Request.EvCode = (byte)EvCode.ResGameEnd;
        }

        public static object[] Event100(IRaiseEventCallInfo info, IPluginHost host)
        {
            var data = (object[])info.Request.Data;
            return new object[] { (string)data[0] + " FROM THE SERVER" };
        }

        public static object[] Event101(IRaiseEventCallInfo info, IPluginHost host)
        {
            // data[0]: Vector2Int, data[0]: string, data[1] : Int, data[2] : Int
            try
            {
                var data = (object[])info.Request.Data;
                host.LogInfo($"### Event100 received data0: {data[0]}, data1: {data[1]}");

                object[] newData = new object[]
                {
                    "OK", (int)data[0], (int)data[1]
                };

                return newData;
            }
            catch (Exception e)
            {
                host.LogInfo($"### Event100: Exception - {e.Message}");
                host.LogInfo($"### Event100: The data type doesn't match. Check Casting Codes");
                return new object[] { "Error" };
            }

        }
    }
}
