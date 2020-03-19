using UnityEngine;
using UnityEditor;

public class Card_Defend : Card
{
    public Card_Defend()
    {
        this.name = "防御";
        this.description = "获得5点护甲";
        this.icon = IconLab.instance.defend;
        this.needTarget = false;
        this.cost = 1;
        
    }
    public override void effect(SequenceCmd sc, Actor actorModel)
    {
        var tim = new SequenceCmd();
        Logic.I.addShield(tim, Player.I.playerActor,5);


        //动画
        sc.add(new Ani(tim));
    }


    public class Ani : Cmd
    {
        public Cmd tim;
        public Ani(Cmd tim)
        {
            this.tim = tim;
        }
        public override void excute()
        {
            run(tim,null);
            EffectAniCtl.instance.playAni(EffectAniLab.instance.defend, IDCtl.instance.getActorView(Player.I.playerActor.id).transform.position);
            run(new WaitCmd(0.3f), () =>
            {
                this.finish();
            });
        }
    }
}