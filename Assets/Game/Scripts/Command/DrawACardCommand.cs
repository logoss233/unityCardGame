using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawACardCommand : Command
{
    public override void excute()
    {
        HandView.instance.drawCard();
        runCommand(new WaitCommand(0.5f), () =>
        {
            this.finish();
        });
    }

}
