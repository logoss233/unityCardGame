using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel
{
    public int id;
    public string name="打击";
    public string description="造成6点伤害";
    public int damage = 6;
    public void use(ActorModel actorModel)
    {
        var sc = new SequenceCommand();
        
        Logic.instance.damage(sc, actorModel, damage);

        var attackAni=new AttackAniCommand(actorModel.id, sc);


        CommandCtl.instance.addCommand(attackAni);
    }
}
