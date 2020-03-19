using UnityEngine;
using UnityEditor;
using HutongGames.PlayMaker;

public class CardViewStateNeedTarget : FsmStateAction
{
    public FsmEvent yesEvent;
    public FsmEvent noEvent;
    public override void OnEnter()
    {
        var cardView = Owner.GetComponent<CardView>();
        var card = cardView.cardModel;
        if (card.needTarget)
        {
            Fsm.Event(yesEvent);
        }
        else
        {
            Fsm.Event(noEvent);
        }
    }
}