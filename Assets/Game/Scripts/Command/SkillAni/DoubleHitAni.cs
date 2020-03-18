using UnityEngine;
using System.Collections;

public class DoubleHitAni : Cmd
{
    int actorId;
    Cmd sc1;
    Cmd sc2;

    public DoubleHitAni(int actorId,Cmd sc1,Cmd sc2)
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
            run(sc1,()=> {
                run(new WaitCmd(0.2f),()=> {
                    EffectAniCtl.instance.playAni(EffectAniLab.instance.claw, actorView.transform.position);
                    run(new WaitCmd(0.3f),()=> {
                        run(sc2, () => {
                            run(new WaitCmd(0.2f),()=> {
                                this.finish();
                            });
                        });
                    });
                });
            });
        });
    }
}
