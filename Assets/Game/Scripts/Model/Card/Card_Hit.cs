using UnityEngine;
using System.Collections;

public class Card_Hit :Card
{

    public Card_Hit()
    {
        this.name = "打击";
        this.icon = IconLab.instance.hit;
        this.description = "造成6点伤害";
        
    }
    public override void effect(SequenceCmd sc, ActorModel actorModel)
    {
        var timing = new SequenceCmd();
        Logic.instance.damage(timing, actorModel, 6);
        var ani = new AttackAni(actorModel.id,timing);
        sc.add(ani);

    }
    public class AttackAni : Cmd
    {
        public int actorId;

        public SequenceCmd sc;
        public AttackAni(int actorId, SequenceCmd timing)
        {
            this.actorId = actorId;
            this.sc = timing;
        }
        public override void excute()
        {
            var actorView = IDCtl.instance.getActorView(this.actorId);
            EffectAniCtl.instance.playAni(EffectAniLab.instance.claw, actorView.transform.position);
            run(new WaitCmd(0.3f), () =>
            {
                run(sc, () => {
                    run(new WaitCmd(0.2f), () =>
                    {
                        this.finish();
                    });
                });
            });
        }

    }
}


