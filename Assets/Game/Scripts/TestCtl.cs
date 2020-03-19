using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCtl : MonoBehaviour
{

    public ActorView playerActorView;
    public ActorView actorView2;
    private void Start()
    {
        Player.I.mana = 3;
        ManaUI.instance.mana = Player.I.mana;
        var player = new Actor();
        player.id = IDCtl.instance.getId();
        player.hp = 30;
        player.maxHp = 30;
        player.shield = 0;
        IDCtl.instance.addActorModel(player);
        Player.I.playerActor = player;


        var enemy = new Actor();
        enemy.id = IDCtl.instance.getId();
        enemy.hp = 60;
        enemy.maxHp = 60;
        enemy.shield = 30;
        IDCtl.instance.addActorModel(enemy);

        playerActorView.init(player.id);
        this.actorView2.init(enemy.id);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //模拟抽卡
            var r = Mathf.Floor(Random.value * 3);
            if ( r== 0)
            {
                var id = IDCtl.instance.getId();
                var cardModel = new Card_Hit();
                cardModel.id = id;
              
                IDCtl.instance.addCardModel(cardModel);

                CmdCtl.instance.addCommand(new DrawACardCmd(cardModel.id));
            }
            else if(r==1)
            {
                var id = IDCtl.instance.getId();
                var cardModel = new Card_DoubleHit();
                cardModel.id = id;
                IDCtl.instance.addCardModel(cardModel);

                CmdCtl.instance.addCommand(new DrawACardCmd(cardModel.id));
            }
            else if(r==2)
            {
                var id = IDCtl.instance.getId();
                var cardModel = new Card_Defend();
                cardModel.id = id;
                IDCtl.instance.addCardModel(cardModel);
                CmdCtl.instance.addCommand(new DrawACardCmd(cardModel.id));
            }
        }
    }
}
