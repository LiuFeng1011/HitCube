using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCubeBullet : BaseHitCubeObj {
    
    Vector3 targetPos ;
    Vector3 startPos;
    float allTime;

    float speed = 5f;
    float moveTime = 0f;

    HitCubeArrow arrow;

    public override enHitCubeObjId GetId()
    {
        return enHitCubeObjId.bullet;
    }
	// Use this for initialization
	void Start () {
        startPos = transform.position;

	}

    public void Init(Vector3 spos, Vector3 tpos, float speed){
        startPos = spos;
        targetPos = tpos;
        this.speed = speed;

        allTime = Vector3.Distance(targetPos, startPos) / speed;

        transform.forward = targetPos - startPos;

        arrow = InGameManager.GetInstance().inGameObjManager.AddObj(BaseHitCubeObj.enHitCubeObjId.arrow) as HitCubeArrow;
        arrow.transform.position = targetPos;
    }

    public override void ObjUpdate()
    {
        base.ObjUpdate();

        moveTime += Time.deltaTime;

        if(moveTime > allTime){
            moveTime = allTime;
        }

        transform.position = startPos + (targetPos - startPos) * (moveTime / allTime);

        if (moveTime >= allTime)
        {
            Bomb();
        }

    }

    public void Bomb(){

        List<BaseHitCubeObj> hitlist = InGameManager.GetInstance().inGameObjManager.GetObjList(transform.position, 0.5f);

        for (int i = 0; i < hitlist.Count; i ++){
            hitlist[i].HitObj(hitlist[i]);
        }

        (new EventCreateEffect(60010010, null, transform.position, transform.localScale.x)).Send();

        arrow.SetDie();

        SetDie();
    }


}
