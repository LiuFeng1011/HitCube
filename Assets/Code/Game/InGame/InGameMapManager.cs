using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMapManager : BaseGameObject {

    Rect gameMapRect;

    float addTime = 0f;

    public override void Init()
    {
        base.Init();

        Vector3 leftDown = GameCommon.ScreenPositionToWorld(new Vector3(0, 0, 0));

        Vector3 rightTop = GameCommon.ScreenPositionToWorld(new Vector3(Screen.width, Screen.height));

        gameMapRect = new Rect(leftDown.x,leftDown.y,rightTop.x - leftDown.x, rightTop.y - leftDown.y);

        addTime = 1f;
    }



    public override void Update()
    {
        base.Update();

        addTime -= Time.deltaTime;

        if (addTime > 0f) return;
        addTime = Random.Range(1f, 3f);

        //随机出生点

        float x = gameMapRect.x * 2f + Random.Range(1, gameMapRect.width * 2f);
        float y = gameMapRect.y + gameMapRect.height + 1f;

        float targetx = 0f;
        if (x < 0f) targetx = gameMapRect.x + Random.Range(1f, gameMapRect.width * 1.5f);
        else targetx = gameMapRect.x + gameMapRect.width - Random.Range(1f, gameMapRect.width * 1.5f);

        float targety = gameMapRect.y - 1f;

        //移动轨迹不能与y轴平行，如果平行手动+1
        if (Mathf.Abs(targetx - x) <= 0.1f) targetx += 1f;

        //保证出生点在屏幕边缘
        if (x < gameMapRect.x - 1f){
            y = GameCommon.GetLineY(new Vector3(x, y), new Vector3(targetx, targety), gameMapRect.x - 1);

            x = gameMapRect.x - 1f;
        }else if(x > gameMapRect.x + gameMapRect.width + 1f){
            y = GameCommon.GetLineY(new Vector3(x, y), new Vector3(targetx, targety), gameMapRect.x + gameMapRect.width + 1f);
            x = gameMapRect.x + gameMapRect.width + 1f;
        }

        Vector3 startPos = new Vector3(x, y);
        Vector3 targetPos = new Vector3(targetx, targety);

        HitCubeEnemy enemy = InGameManager.GetInstance().inGameObjManager.AddObj(BaseHitCubeObj.enHitCubeObjId.enemy) as HitCubeEnemy;

        enemy.Init(startPos, targetPos, Random.Range(0.5f, 3f), Random.Range(0.3f, 0.6f));

    }

    public bool objIsInScreen(Vector3 pos){
        return gameMapRect.Contains(pos);
    }

    //是否在屏幕外
    public bool objIsOut(float x, float y, float w, float h){
        return !GameCommon.isCollisionWithRect(
            gameMapRect.x,gameMapRect.y,gameMapRect.width,gameMapRect.height,
            x,y,w,h);
    }
}
