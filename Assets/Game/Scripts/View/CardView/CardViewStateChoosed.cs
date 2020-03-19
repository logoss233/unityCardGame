using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class CardViewStateChoosed :FsmStateAction
{
    public FsmEvent cancel;
    public FsmEvent comfirm;

    CardView cardView;
    Transform transform;

    public override void Awake()
    {
        cardView = Owner.GetComponent<CardView>();
        transform = Owner.transform;
    }
    public override void OnEnter()
    {
        
    }
    public override void OnExit()
    {
        cardView.isShowYellowBackLight = false;
    }
    public override void OnUpdate()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        cardView.transform.position = Vector3.Lerp(cardView.transform.position, mousePos, 0.3f);
        if (Input.GetMouseButtonDown(1))
        {
            Fsm.Event(this.cancel);
            HandView.instance.cancelChoose();
            return;
        }
        if (transform.position.y > HandView.instance.commitPoint.position.y)
        {
            if (cardView.cardModel.canUse)
            {
                Fsm.Event(this.comfirm);
                return;
            }
            else
            {
                Fsm.Event(this.cancel);
                HandView.instance.cancelChoose();
            }
            
        }
        //黄光效果
        cardView.isShowYellowBackLight = cardView.cardModel.canUse;
    }
    
}
