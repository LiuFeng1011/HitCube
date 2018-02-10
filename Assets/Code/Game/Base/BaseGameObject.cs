using UnityEngine;
using System.Collections;

public class BaseGameObject : EventObserver {

    public virtual void Init(){
        
    }


    public virtual void Update()
    {

    }

    public virtual void Destroy(){
        
    }

    public virtual void HandleEvent(EventData resp){
		
	}
}
