using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawACardCommand : Command
{
    int cardId;
    public DrawACardCommand(int cardId)
    {
        this.cardId = cardId;
    }
    public override void excute()
    {
        HandView.instance.drawCard(cardId);
        runCommand(new WaitCommand(0.5f), () =>
        {
            this.finish();
        });
    }

}
