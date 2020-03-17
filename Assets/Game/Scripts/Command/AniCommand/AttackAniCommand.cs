using UnityEngine;
using UnityEditor;

public class AttackAniCommand : Command
{
    public int actorId;

    public SequenceCommand sc;
    public AttackAniCommand(int actorId,SequenceCommand sc)
    {
        this.actorId = actorId;
        this.sc = sc;
    }
    public override void excute()
    {
        var actorView = IDCtl.instance.getActorView(this.actorId);
        EffectAniCtl.instance.playAni(EffectAniLab.instance.claw,actorView.transform.position);
        runCommand(new WaitCommand(0.3f), () =>
        {
            runCommand(sc, () => {
                runCommand(new WaitCommand(0.2f), () =>
                {
                    this.finish();
                });
            });
        });
    }
    
}