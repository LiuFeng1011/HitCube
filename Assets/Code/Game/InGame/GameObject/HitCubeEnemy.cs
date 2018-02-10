using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCubeEnemy : BaseHitCubeObj {
    const float maxspeed = 180f; 

    Vector3 startPos;
    Vector3 targetPos;
    float speed;
    Vector3 moveVector;

    bool show = false;

    float bombtime = -1;

    GameObject sprite;

    Vector3 rotation;

    public override enHitCubeObjId GetId()
    {
        return enHitCubeObjId.enemy;
    }
	// Use this for initialization
	void Start () {
		
	}

    public void Init(Vector3 spos, Vector3 tpos, float speed, float scale )
    {
        //Rigidbody rb = transform.GetComponent<Rigidbody>();
        //Vector3 force = tpos - spos;
        //rb.velocity = force.normalized * speed;

        startPos = spos;
        transform.position = spos;
        targetPos = tpos;

        this.speed = speed;
        moveVector = (tpos - spos).normalized;

        sprite = transform.Find("sprite").gameObject;

        rotation = new Vector3(0,Random.Range(-maxspeed, maxspeed), Random.Range(-maxspeed, maxspeed));
        transform.localScale = transform.localScale * scale;
    }

	// Update is called once per frame
	void Update () {
		
	}

    public override void ObjUpdate()
    {
        if (bombtime >= 0)
        {
            bombtime += Time.deltaTime;
            if (bombtime > 1f){
                SetDie();
            }
            return;
        }
        base.ObjUpdate();

        transform.Rotate(rotation * Time.deltaTime);

        transform.position = transform.position + moveVector * speed * Time.deltaTime;

        if(!show){
            if(InGameManager.GetInstance().inGameMapManager.objIsInScreen(transform.position)){
                show = true;
            }
        }else{
            //是否移出屏幕
            if(InGameManager.GetInstance().inGameMapManager.objIsOut(
                transform.position.x - transform.localScale.x / 2,
                transform.position.y - transform.localScale.x / 2,
                transform.localScale.x,transform.localScale.y)){
                SetDie();
            }
        }

    }

    public override void HitObj(BaseHitCubeObj obj)
    {
        if (bombtime >= 0){
            return;
        }
        base.HitObj(obj);

        if(obj.GetId() == enHitCubeObjId.enemy){
            Bomb();
        }
    }

    public void Bomb (){
        bombtime = 0;
        sprite.SetActive(false);
        gameObject.SetActive(false);

        (new EventCreateEffect(60010010, null, transform.position, transform.localScale.x)).Send();

        InGameManager.GetInstance().imageEffect_MoblieBloom.threshold = 1f;
    }
}
