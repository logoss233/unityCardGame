using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;
using DG.Tweening;
using UnityEngine.UI;


public class CardViewStateUse : FsmStateAction
{
    CardView cardView;
    CanvasGroup canvasGroup;
    public override void OnEnter()
    {
        cardView = Owner.GetComponent<CardView>();
        var transform = Owner.transform;
        canvasGroup = Owner.GetComponent<CanvasGroup>();
        
        HandView.instance.removeCardView(cardView);
        HandView.instance.cancelChoose();

        Owner.GetComponent<GraphicRaycaster>().enabled = false;

        transform.DOMove(transform.position + new Vector3(0, 300, 0), 1f);
        canvasGroup.DOFade(0, 1f).OnComplete(()=> {
            GameObject.Destroy(Owner);
        });


    }

}
