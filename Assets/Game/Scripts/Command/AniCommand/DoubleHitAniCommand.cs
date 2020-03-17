using UnityEngine;
using System.Collections;

public class DoubleHitAniCommand : Command
{
    int actorId;
    Command sc1;
    Command sc2;

    public DoubleHitAniCommand(int actorId,Command sc1,Command sc2)
    {
        this.actorId = actorId;
        this.sc1 = sc1;
        this.sc2 = sc2;

    }

    public override void excute()
    {
        var actorView = IDCtl.instance.getActorView(actorId);
        EffectAniCtl.instance.playAni(EffectAniLab.instance.blow, actorView.transform.position);
        runCommand(new WaitCommand(0.3f), () =>
        {
            runCommand(sc1,()=> {
                runCommand(new WaitCommand(0.2f),()=> {
                    EffectAniCtl.instance.playAni(EffectAniLab.instance.claw, actorView.transform.position);
                    runCommand(new WaitCommand(0.3f),()=> {
                        runCommand(sc2, () => {
                            runCommand(new WaitCommand(0.2f),()=> {
                                this.finish();
                            });
                        });
                    });
                });
            });
        });
    }
}
