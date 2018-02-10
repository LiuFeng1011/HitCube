using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayerManager : BaseGameObject {

    HitCubeRole role = null;

	public override void Init()
    {
        base.Init();

        role = InGameManager.GetInstance().inGameObjManager.AddObj(BaseHitCubeObj.enHitCubeObjId.role) as HitCubeRole;


        Vector3 screenpos = new Vector3(Screen.width / 2, 0, 0);
        role.transform.position = GameCommon.ScreenPositionToWorld(screenpos);

        EventManager.Register(this,
                              EventID.EVENT_TOUCH_DOWN);
    }

    public override void HandleEvent(EventData resp)
    {

        switch (resp.eid)
        {
            case EventID.EVENT_TOUCH_DOWN:
                EventTouch eve = (EventTouch)resp;
                Fire(GameCommon.ScreenPositionToWorld(eve.pos));
                break;
        }

    }
    public override void Destroy()
    {
        EventManager.Remove(this);
    }

    public void Fire(Vector3 targetpos){
        
        HitCubeBullet bullet = InGameManager.GetInstance().inGameObjManager.AddObj(BaseHitCubeObj.enHitCubeObjId.bullet) as HitCubeBullet;
        bullet.Init(role.transform.position,targetpos,4);
        (new EventCreateEffect(60010011, bullet.gameObject, bullet.transform.position, bullet.transform.localScale.x)).Send();
    }

}
