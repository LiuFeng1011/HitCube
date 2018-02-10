using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LogoFinished", 0.5f);
	}
	
    //加载配置表完成
    void LogoFinished()
    {
        (new EventChangeScene(GameSceneManager.SceneTag.Menu)).Send();
    }

}
