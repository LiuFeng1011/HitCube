﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEffect : MonoBehaviour {
	public conf_effect conf{get;private set;}
	ParticleSystem ps ;
	long playTime;
    public GameObject parent;
    bool haveParent = false;

	public void Init(conf_effect conf){
		this.conf = conf;
		ps = transform.GetComponent<ParticleSystem>();

		gameObject.SetActive(false);
        Stop();
	}

	public void Play(float scale){
		playTime = InGameManager.gameTime;

		gameObject.SetActive(true);

        Play();

        SetScale(transform, scale);
	}

    public void SetScale(Transform t, float scale){
        for (int i = 0; i < t.childCount; i ++){
            SetScale(t.GetChild(i),scale);
        }
        t.localScale = new Vector3(scale, scale, scale);
    }

	void Update(){
        if (parent != null)
        {
            transform.position = parent.transform.position;
            //transform.forward = parent.transform.forward;
            return;
        }
        if(haveParent){
            playTime = InGameManager.gameTime;
            haveParent = false;
            Stop();
        }

		//if(conf.loop == 1){
		//	return;
		//}

		if(InGameManager.gameTime - playTime > ps.main.duration*1000){
			Die();
		}
	}

    public void SetParent(GameObject obj){
        this.parent = obj;
        haveParent = true;
    } 

	public void Die(){
		//gameObject.transform.parent = null;
		gameObject.SetActive(false);
        transform.position = new Vector3(-999999, -999999, 0);
		//Destroy(gameObject);
	}

	void OnDestroy(){
		//Debug.Log("Destroy effect !!!!!!!!!!!!!!! : " + conf.id);
	}

    void Play(){
        ps.Play();

    }
    void Stop(){
        ps.Stop();
    }
}
