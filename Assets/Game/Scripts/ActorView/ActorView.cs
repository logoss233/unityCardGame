using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorView : MonoBehaviour
{
   
    public static ActorView mousePosActor;
    public Image image;
    public int id;
    public ActorModel actorModel;
    public HitEffect hitEffect;
    private void Start()
    {
        image.material = Instantiate(image.material);
    }
    public void init(int id)
    {
        this.id = id;
        IDCtl.instance.addActorView(this);
        var actorModel = IDCtl.instance.getActorModel(id);
        this.actorModel = actorModel;
        this.hp = actorModel.hp;

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
    //=======选中效果
    public bool _isSelect = false;
    public bool isSelect { get { return this._isSelect; } set {
            this._isSelect = value;
            if (value)
            {
                
                this.image.material.EnableKeyword("OUTBASE_ON");
            }
            else
            {
                
                this.image.material.DisableKeyword("OUTBASE_ON");
            }
            
        } }

    //====
   
    public Text hpText;
    public int hp = 50;
    private void Update()
    {
        this.hpText.text = this.hp.ToString();
    }
    //=====受伤
    public void damage(int dmg,int hpAfter)
    {
        this.hp = hpAfter;
        hitEffect.play();

    }
    
}
