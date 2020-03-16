using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorView : MonoBehaviour
{
   
    public static ActorView mousePosActor;
    public Image image;
    
    private void Start()
    {
        image.material = Instantiate(image.material);
    }
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
    //=======
    public bool _isSelect = false;
    public GameObject selectTip;
    public bool isSelect { get { return this._isSelect; } set {
            this._isSelect = value;
            if (value)
            {
                print("glow_on");
                this.image.material.EnableKeyword("OUTBASE_ON");
            }
            else
            {
                print("glow_off");
                this.image.material.DisableKeyword("OUTBASE_ON");
            }
            
        } }
}
