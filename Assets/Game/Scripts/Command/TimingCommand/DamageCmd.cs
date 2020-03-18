using UnityEngine;
using System.Collections;

public class DamageCmd : Cmd
{
    int actorId;
    int damage;
    int hpAfter;
    public DamageCmd ( int actorId ,int damage,int hpAfter)
    {
        this.actorId = actorId;
        this.damage = damage;
        this.hpAfter = hpAfter;
    }
    public override void excute()
    {
        ActorView actorView = IDCtl.instance.actorViewDic[this.actorId];
        actorView.damage(damage, hpAfter);

        this.finish();
    }
    
}
