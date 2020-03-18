using UnityEngine;
using UnityEditor;
using HutongGames.PlayMaker;
using DG.Tweening;

public class CardViewStateCancel :FsmStateAction
{
    

    public override void OnEnter()
    {
        var transform = Owner.transform;
        var cardView = Owner.GetComponent<CardView>();
        
        transform.DOMove(cardView.targetPos, 0.25f).OnComplete(()=>
        {
            this.Finish();
        });
        transform.DOScale(new Vector3(1, 1, 1), 0.25f);
        transform.DOLocalRotateQuaternion(Quaternion.identity, 0.25f);
    }
    
}