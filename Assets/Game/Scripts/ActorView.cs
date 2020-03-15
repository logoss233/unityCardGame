using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorView : MonoBehaviour
{
    public static ActorView mousePosActor;
    public void onPointEnter()
    {
        ActorView.mousePosActor = this;
    }
    public void onPointExit()
    {
        if (ActorView.mousePosActor == this)
        {
            ActorView.mousePosActor = null;
        }
    }
    //=========
}
