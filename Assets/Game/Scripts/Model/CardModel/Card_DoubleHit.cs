using UnityEngine;
using UnityEditor;

public class Card_DoubleHit : CardModel
{
   public Card_DoubleHit()
    {
        this.name = "连击";
        this.description = "造成5点伤害2次";
        
    }
    public override void use(ActorModel actorModel)
    {
        var sc1 = new SequenceCommand();

        Logic.instance.damage(sc1, actorModel, 5);

        var sc2 = new SequenceCommand();
        Logic.instance.damage(sc2, actorModel, 5);

        var attackAni = new DoubleHitAniCommand(actorModel.id, sc1,sc2);


        CommandCtl.instance.addCommand(attackAni);
    }
}