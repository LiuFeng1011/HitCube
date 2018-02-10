using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCubeArrow : BaseHitCubeObj {

    const float maxspeed = 360f; 
    Vector3 rotation;
    float scale = 3.0f;
    float minscale = 0.4f;
    public override enHitCubeObjId GetId()
    {
        return enHitCubeObjId.arrow;
    }
    void Start()
    {
        rotation = new Vector3(0, 0, maxspeed);
        transform.localScale = new Vector3(5.0f, 5.0f, 1f);
    }


    public override void ObjUpdate()
    {
        base.ObjUpdate();
        transform.Rotate(rotation * Time.deltaTime);
        if (scale > minscale){
            scale -= 3.5f * Time.deltaTime * 2;
            transform.localScale = new Vector3(scale, scale, 1f);
        }else{

            transform.localScale = new Vector3(minscale, minscale, 1f);
        }
    }

}
