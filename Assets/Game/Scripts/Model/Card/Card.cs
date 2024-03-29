﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card
{
    public int id;
    public string name="";
    public string description="";
    public Sprite icon; //图片
    public bool needTarget = true; //是否指向
    public int cost = 1; //费用

    
    public bool canUse
    {
        get
        { 
            if (Player.I.mana >= this.cost && GameTurn.I.state==GameTurn.State.playerTurn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void use(Actor actorModel)
    {
        Player.I.hand.Remove(this);
        
        var sc = new SequenceCmd();
        Player.I.mana -= this.cost;
        sc.add(new UpdateManaCmd(Player.I.mana));

        this.effect(sc,actorModel);
        CmdCtl.I.add(sc);

        Player.I.discardDeck.Add(this);
    }
    public abstract void effect(SequenceCmd sc, Actor actorModel);
}
