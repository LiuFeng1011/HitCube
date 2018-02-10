using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseHitCubeObj : BaseUnityObject {

    public enum enHitCubeObjId {
        def,
        role,
        enemy,
        bullet,
        arrow
    }

    public virtual enHitCubeObjId GetId(){
        return enHitCubeObjId.def;
    }

    protected bool isdie = false;

    public virtual void ObjUpdate(){
        
    }


    public virtual bool IsDie(){
        return isdie;
    }

    public virtual void SetDie(){
        isdie = true;
    }

    public virtual void HitObj(BaseHitCubeObj obj){
        
    }
}
