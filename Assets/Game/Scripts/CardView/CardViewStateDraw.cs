using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;
using DG.Tweening;

public class CardViewStateDraw :FsmStateAction
{
    public override void OnEnter()
    {
        var startPos = HandView.instance.drawCardFromPos;
        var endPos = HandView.instance.drawCardEndPos;

        var transform = Owner.transform;
        var cardView = Owner.GetComponent<CardView>();

        transform.position = startPos.position;
        transform.DOMove(endPos.position, 1f).OnComplete(() =>
        {
            this.Finish();
        });
    
       
    }
}
