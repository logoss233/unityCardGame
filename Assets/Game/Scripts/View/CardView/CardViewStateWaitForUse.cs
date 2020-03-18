using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class CardViewStateWaitForUse : FsmStateAction
{

    public override void OnEnter()
    {
        var cardView = Owner.GetComponent<CardView>();
        HandView.instance.removeCardView(cardView);
        HandView.instance.cancelChoose();

    }
}
