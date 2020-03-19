using UnityEngine;
using System.Collections;

public class DamageCmd : Cmd
{
    int actorId;
    int damage;
    int hpAfter;
    int shieldAfter;
    public DamageCmd ( int actorId ,int damage,int hpAfter,int shieldAfter)
    {
        this.actorId = actorId;
        this.damage = damage;
        this.hpAfter = hpAfter;
        this.shieldAfter = shieldAfter;
    }
    public override void excute()
    {
        
        ActorView actorView = IDCtl.instance.actorViewDic[this.actorId];
        actorView.damage(damage, hpAfter,shieldAfter);

        this.finish();
    }
    
}
