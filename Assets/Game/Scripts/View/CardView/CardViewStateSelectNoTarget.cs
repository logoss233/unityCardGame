using UnityEngine;
using UnityEditor;
using HutongGames.PlayMaker;

public class CardViewStateSelectNoTarget : FsmStateAction
{
    CardView cardView;
    Transform transfrom;
    public FsmEvent cancelEvent;
    public FsmEvent confirmEvent;

    public override void Awake()
    {
        cardView = Owner.GetComponent<CardView>();
        transfrom = Owner.transform;
    }
    public override void OnExit()
    {
        cardView.isShowBackLight = false;
    }
    public override void OnUpdate()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transfrom.position = Vector3.Lerp(transfrom.position, mousePos, 0.3f);
        if (transfrom.position.y > HandView.instance.commitPoint.position.y)
        {
            cardView.isShowBackLight = true;
        }
        else
        {
            cardView.isShowBackLight = false;
        }
        //取消
        if (Input.GetMouseButtonDown(1))
        {
            this.cancel();
            return;
        }
        if (mousePos.y < -300)
        {
            this.cancel();
            return;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            if (transfrom.position.y > HandView.instance.commitPoint.position.y)
            {
                //确认使用
                cardView.cardModel.use(null);
                this.Fsm.Event(this.confirmEvent);
            }
        }
    }
    void cancel()
    {
        HandView.instance.cancelChoose();
        Fsm.Event(this.cancelEvent);
    }
}