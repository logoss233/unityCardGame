using UnityEngine;
using UnityEditor;

public class Card_DoubleHit : Card
{
   public Card_DoubleHit()
    {
        this.name = "连击";
        this.description = "造成5点伤害2次";
        this.icon = IconLab.instance.doubleHit;
    }
    public override void effect(SequenceCmd sc, ActorModel actorModel)
    {
        var sc1 = new SequenceCmd();

        Logic.instance.damage(sc1, actorModel, 5);

        var sc2 = new SequenceCmd();
        Logic.instance.damage(sc2, actorModel, 5);

        var attackAni = new DoubleHitAni(actorModel.id, sc1,sc2);

        sc.add(attackAni);
       
    }
}