using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorView : MonoBehaviour
{
   
    public static ActorView mousePosActor;
    public Image image;
    public int id;
    public Actor actorModel;
    public HitEffect hitEffect;
    
    public void init(int id)
    {
        image.material = Instantiate(image.material);
        this.id = id;
        IDCtl.instance.addActorView(this);
        this.actorModel = IDCtl.instance.getActorModel(id);
        this.hp = actorModel.hp;
        this.maxHp = actorModel.maxHp;

        this.hpBar.init(this.hp,this.maxHp,this.actorModel.shield);
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

    public HPBar hpBar;
    public int hp = 50;
    public int maxHp = 50;
    public ParticleSystem hitParticle;
    private void Update()
    {
       // this.hpText.text = this.hp.ToString();
    }
    /// <summary>
    /// 受到伤害
    /// </summary>
    /// <param name="dmg">减血值</param>
    /// <param name="hpAfter"></param>
    /// <param name="shieldAfter"></param>
    public void damage(int dmg,int hpAfter,int shieldAfter)
    {
        
        this.hp = hpAfter;
        this.hpBar.hp = this.hp;
        this.hpBar.shield = shieldAfter;
        if (dmg > 0)
        {
            JumpNumCtl.instance.jumpDamage(dmg, transform.position);
        }
        
        hitEffect.play();
        hitParticle.Play();

    }
    
}
