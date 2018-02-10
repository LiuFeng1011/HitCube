using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : BaseUnityObject {

    public static long gameTime;

    static InGameManager instance;

    public InGameStateManager inGameStateManager { get; private set; }
    public InGameObjManager inGameObjManager{ get; private set; }
    public InGamePlayerManager inGamePlayerManager{ get; private set; }
    public InGameMapManager inGameMapManager{ get; private set; }
    public ImageEffect_MoblieBloom imageEffect_MoblieBloom{ get; private set; }


    private GameEffectManager gameEffectManager;


    GamePlayerController gamePlayerController;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        gamePlayerController = new GamePlayerController();

        inGameStateManager = new InGameStateManager();
        inGameStateManager.Init();

        inGameObjManager = new InGameObjManager();
        inGameObjManager.Init();

        inGamePlayerManager = new InGamePlayerManager();
        inGamePlayerManager.Init();

        inGameMapManager = new InGameMapManager();
        inGameMapManager.Init();

        gameEffectManager = new GameEffectManager();

        imageEffect_MoblieBloom = GameObject.Find("Main Camera").GetComponent<ImageEffect_MoblieBloom>();

	}
	
	// Update is called once per frame
    void Update () {
        gameTime = GameCommon.GetTimeStamp(false);

        gamePlayerController.Update();

        inGameStateManager.Update();
        inGameObjManager.Update();
        inGamePlayerManager.Update();
        inGameMapManager.Update();
	}

    private void OnDestroy()
    {
        instance = null;

        if(inGameObjManager != null) inGameObjManager.Destroy();
        if (inGameObjManager != null) inGameStateManager.Destroy();
        if (inGameObjManager != null) inGamePlayerManager.Destroy();
        if (inGameMapManager != null) inGameMapManager.Destroy();
        if (gameEffectManager != null) gameEffectManager.OnDestroy();
    }

    public static InGameManager GetInstance(){
        return instance;
    }
}
