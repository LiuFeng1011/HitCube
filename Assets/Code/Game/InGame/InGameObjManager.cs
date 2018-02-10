using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InGameObjManager : BaseGameObject {

    public override void Init()
    {
        base.Init();
    } 

    public override void Destroy()
    {
        base.Destroy();
    }

    List<BaseHitCubeObj> objlist = new List<BaseHitCubeObj>();

    public BaseHitCubeObj AddObj(BaseHitCubeObj.enHitCubeObjId id)
    {
        string filename = Enum.GetName(typeof(BaseHitCubeObj.enHitCubeObjId), id);

        GameObject obj = (GameObject)Resources.Load("Prefabs/MapObj/" + filename);

        obj = MonoBehaviour.Instantiate(obj);

        BaseHitCubeObj baseobj = obj.GetComponent<BaseHitCubeObj>();

        objlist.Add(baseobj);

        return baseobj;
    }

    public override void Update()
    {
        base.Update();

        List<BaseHitCubeObj> dellist = new List<BaseHitCubeObj>();

        for (int i = 0; i < objlist.Count; i ++){
            BaseHitCubeObj obj = objlist[i];
            obj.ObjUpdate();

            for (int j = i+1; j < objlist.Count; j++)
            { 
                BaseHitCubeObj obj2 = objlist[j];

                if(Vector3.Distance(obj2.transform.position , obj.transform.position) < 
                   (obj2.transform.localScale.x + obj.transform.localScale.x) / 2){
                    obj2.HitObj(obj);
                    obj.HitObj(obj2);
                }
            }

            if(obj.IsDie()){
                dellist.Add(obj);
            }
        }

        for (int i = 0; i < dellist.Count; i ++){
            objlist.Remove(dellist[i]);
            GameObject.Destroy(dellist[i].gameObject);
        }

    }

    public List<BaseHitCubeObj> GetObjList(Vector3 pos, float dis){
        List<BaseHitCubeObj> ret = new List<BaseHitCubeObj>();
        for (int i = 0; i < objlist.Count; i++)
        {
            BaseHitCubeObj obj = objlist[i];

            if(Vector3.Distance(obj.transform.position ,pos) < dis){
                ret.Add(obj);
            }
        }
        return ret;

    }
}
