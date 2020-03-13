using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;
using DG.Tweening;

public class CardViewStateDraw :FsmStateAction
{
    public Transform startPos;
    public Transform endPos;
    public override void OnEnter()
    {
        var transform = Owner.transform;
        var cardView = Owner.GetComponent<CardView>();

        transform.position = startPos.position;
        transform.DOMove(endPos.position, 1f).OnComplete(() =>
        {
            this.Finish();
        });
        cardView.isFace = false;
        transform.localRotation=Quaternion.Euler(new Vector3(0,-180,0));
        transform.DOLocalRotate(new Vector3(0, -90, 0),0.5f).OnComplete(()=> {
            cardView.isFace = true;
            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
        });
    }
}
