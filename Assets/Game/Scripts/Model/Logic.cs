using UnityEngine;
using System.Collections;

public class Logic 
{
    private static Logic _instance;
    public static Logic I
    {
        get
        {
            if (Logic._instance==null)
            {
                Logic._instance = new Logic();
            }
            return Logic._instance;
        }
    }
    

    public void damage(SequenceCmd sc,Actor actor,int dmg)
    {
        actor.shield -= dmg;
        dmg = 0;
        if (actor.shield < 0)
        {
            dmg = -actor.shield;
            actor.shield = 0;
        }
        actor.hp -= dmg;

        sc.add(new DamageCmd(actor.id, dmg, actor.hp,actor.shield));
    }
    public void addShield(SequenceCmd sc,Actor actor,int num)
    {
        actor.shield += num;
        sc.add(new AddShieldCmd(actor.id, actor.shield));

    }

}
