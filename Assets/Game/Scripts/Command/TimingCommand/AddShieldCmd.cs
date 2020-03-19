using UnityEngine;
using UnityEditor;

public class AddShieldCmd: Cmd
{
    public int actorId;
    public int shieldAfter;
    public AddShieldCmd(int actorId,int shieldAfter)
    {
        this.actorId = actorId;
        this.shieldAfter = shieldAfter;
    }
    public override void excute()
    {
        var actorView = IDCtl.instance.getActorView(this.actorId);
        actorView.hpBar.shield = this.shieldAfter;
        this.finish();
    }
}