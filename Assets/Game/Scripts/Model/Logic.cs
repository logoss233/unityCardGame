using UnityEngine;
using System.Collections;

public class Logic 
{
    private static Logic _instance;
    public static Logic instance
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
    

    public void damage(SequenceCmd sc,ActorModel actorModel,int num)
    {
        actorModel.hp -= num;

        sc.add(new DamageCmd(actorModel.id, num, actorModel.hp));
    }


}
