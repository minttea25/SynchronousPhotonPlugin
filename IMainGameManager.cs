using System.Collections.Generic;

namespace SynchronousPlugin.KWY
{
    interface IMainGameManager
    {
        Dictionary<string, ActionData> userActionData { get; }
        ActionData NowActionData { get; }


        // 아직 playerskill을 어떻게 할건지 정하지 못함: 일단 master-client에서 실행되면 그 외 클라이언트에서도 똑같이 실행되도록 (기본 photon 동기화) 이용

        ActionData CombineActionData();

        void ResetData();

        //void CalcWithPlayerSkill(int playerSkill);

        bool SetActionData(string id, ActionData actionData);
        bool RemoveUser(string id);

        bool CheckAllReady();
    }
}
