﻿using System.Collections;
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
        actorModel2.maxHp = 60;
        IDCtl.instance.addActorModel(actorModel2);

     
        this.actorView2.init(actorModel2.id);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //模拟抽卡
            if (Mathf.Floor(Random.value * 2) == 0)
            {
                var id = IDCtl.instance.getId();
                var cardModel = new Card_Hit();
                cardModel.id = id;
              
                IDCtl.instance.addCardModel(cardModel);

                CmdCtl.instance.addCommand(new DrawACardCmd(cardModel.id));
            }
            else
            {
                var id = IDCtl.instance.getId();
                var cardModel = new Card_DoubleHit();
                cardModel.id = id;
                IDCtl.instance.addCardModel(cardModel);

                CmdCtl.instance.addCommand(new DrawACardCmd(cardModel.id));
            }

            
            
        }
    }
}
