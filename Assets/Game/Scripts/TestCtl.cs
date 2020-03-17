using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCtl : MonoBehaviour
{
  
    public ActorView actorView2;
    private void Start()
    {


     


        var actorModel2 = new ActorModel();
        actorModel2.id = IDCtl.instance.getId();
        actorModel2.hp = 60;
        IDCtl.instance.addActorModel(actorModel2);

     
        this.actorView2.init(actorModel2.id);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //模拟抽卡
            var id = IDCtl.instance.getId();
            var cardModel = new CardModel();
            cardModel.id = id;
            cardModel.name = "card" + id;
            cardModel.damage =(int)Random.Range(3, 8);
            cardModel.description = "造成" + cardModel.damage + "点伤害";
            IDCtl.instance.addCardModel(cardModel);

            CommandCtl.instance.addCommand(new DrawACardCommand(cardModel.id));
            
        }
    }
}
