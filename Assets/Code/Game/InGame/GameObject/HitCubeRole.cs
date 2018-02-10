using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCubeRole : BaseHitCubeObj {

    public override enHitCubeObjId GetId()
    {
        return enHitCubeObjId.role;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void ObjUpdate()
    {
        base.ObjUpdate();
    }
}
