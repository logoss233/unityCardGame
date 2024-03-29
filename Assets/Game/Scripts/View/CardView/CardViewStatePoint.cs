﻿using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class CardViewStatePoint : FsmStateAction
{
    CardView cardView;
    Transform transform;
    public FsmEvent pointExitEvent;
    public FsmEvent mouseDown;
    public override void OnEnter()
    {
        transform= Owner.transform;
        cardView = Owner.GetComponent<CardView>();
        transform.position = new Vector3(cardView.targetPos.x, -210, 0);

        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(2, 2, 1f);

        Owner.GetComponent<Canvas>().sortingOrder = 50;
    }
    public override void OnExit()
    {
        
    }
    public override void OnUpdate()
    {
        if (CardView.mousePosCard != this.cardView)
        {
            Fsm.Event(pointExitEvent);
            HandView.instance.cancelChoose();
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Fsm.Event(mouseDown);
            return;
        }

        //黄光效果
        cardView.isShowYellowBackLight = cardView.cardModel.canUse;
    }
}
