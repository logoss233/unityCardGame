using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card
{
    public int id;
    public string name="";
    public string description="";
    public Sprite icon;
    
    public void use(ActorModel actorModel)
    {
        var sc = new SequenceCmd();
        this.effect(sc,actorModel);

        CmdCtl.instance.addCommand(sc);
    }
    public abstract void effect(SequenceCmd sc, ActorModel actorModel);
}
