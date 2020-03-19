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
    public override void effect(SequenceCmd sc, Actor actorModel)
    {
        var sc1 = new SequenceCmd();

        Logic.I.damage(sc1, actorModel, 5);

        var sc2 = new SequenceCmd();
        Logic.I.damage(sc2, actorModel, 5);

        var attackAni = new DoubleHitAni(actorModel.id, sc1,sc2);

        sc.add(attackAni);
       
    }


    public class DoubleHitAni : Cmd
    {
        int actorId;
        Cmd sc1;
        Cmd sc2;
        public DoubleHitAni(int actorId, Cmd sc1, Cmd sc2)
        {
            this.actorId = actorId;
            this.sc1 = sc1;
            this.sc2 = sc2;
        }
        public override void excute()
        {
            var actorView = IDCtl.instance.getActorView(actorId);
            EffectAniCtl.instance.playAni(EffectAniLab.instance.blow, actorView.transform.position);
            run(new WaitCmd(0.3f), () =>
            {
                run(sc1, () => {
                    run(new WaitCmd(0.2f), () => {
                        EffectAniCtl.instance.playAni(EffectAniLab.instance.claw, actorView.transform.position);
                        run(new WaitCmd(0.3f), () => {
                            run(sc2, () => {
                                run(new WaitCmd(0.2f), () => {
                                    this.finish();
                                });
                            });
                        });
                    });
                });
            });
        }
    }
}