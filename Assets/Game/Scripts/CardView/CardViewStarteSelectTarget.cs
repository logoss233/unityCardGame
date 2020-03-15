using UnityEngine;
using UnityEditor;
using HutongGames.PlayMaker;

public class CardViewStarteSelectTarget : FsmStateAction
{
    CardView cardView;
    Transform transform;
    public FsmEvent cancelEvent;
    
    public override void Awake()
    {
        cardView = Owner.GetComponent<CardView>();
        transform = Owner.transform;
    }

    public override void OnEnter()
    {
        ArrowCtl.instance.open();
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ArrowCtl.instance.set(transform.position, mousePos);
    }
    public override void OnExit()
    {
        ArrowCtl.instance.close();
    }
    public override void OnUpdate()
    {
        transform.position=Vector3.Lerp(transform.position, HandView.instance.centerPoint.position+new Vector3(0,50,0), 0.3f);
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.5f, 1.5f, 1), 0.3f);

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ArrowCtl.instance.set(transform.position, mousePos);

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
    }
    void cancel()
    {
        HandView.instance.cancelChoose();
        Fsm.Event(this.cancelEvent);
    }
    
}