using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawACardCmd : Cmd
{
    int cardId;
    public DrawACardCmd(int cardId)
    {
        this.cardId = cardId;
    }
    public override void excute()
    {
        HandView.instance.drawCard(cardId);
        run(new WaitCmd(0.5f), () =>
        {
            this.finish();
        });
    }

}
