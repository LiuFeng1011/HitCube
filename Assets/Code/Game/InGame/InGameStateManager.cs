using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateManager : BaseGameObject {

    public enum enGameState{
        ready,
        play,
        pause,
        over,
    }

    enGameState gameState;

    public enGameState GetState(){
        return gameState;
    }

    public void SetState(enGameState s){
        gameState = s;
    }

    public override void Init()
    {
        base.Init();
    }


}
