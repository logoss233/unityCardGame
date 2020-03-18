using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class CardViewStateIdle : FsmStateAction
{
    CardView cardView;
    Transform transform;
    //public FsmEvent pointEnterEvent;
    public override void OnEnter()
    {
        
        cardView = Owner.GetComponent<CardView>();
        transform = Owner.transform;

        Owner.GetComponent<Canvas>().sortingOrder = cardView.orderInhand;
    }
    public override void OnUpdate()
    {
        //if (CardView.mousePosCard == cardView)
        //{
        //    Fsm.Event(pointEnterEvent);
        //    return;
        //}


        if (HandView.instance.controlCard == null)
        {
            cardView.transform.position = Vector3.Lerp(cardView.transform.position, cardView.targetPos, 0.3f);
        }
        else
        {
            var pointIndex = HandView.instance.controlCard.orderInhand;
            var thisIndex = cardView.orderInhand;
            var offIndex = thisIndex - pointIndex;
            float offX = 0;
            if (offIndex != 0)
            {
                offX = (1f /offIndex) * 40;
            }
            cardView.transform.position = Vector3.Lerp(cardView.transform.position, cardView.targetPos+new Vector3(offX,0,0), 0.3f);
        }
        //旋转
        cardView.transform.rotation = Quaternion.Lerp(cardView.transform.rotation, Quaternion.Euler(cardView.targetRotiton), 0.3f);
        //大小
        cardView.transform.localScale = Vector3.Lerp(cardView.transform.localScale, Vector3.one, 0.3f);
    }
}
