using UnityEngine;
using System.Collections;

public class UseCardCmd : Cmd
{
    int cardId;
    public UseCardCmd(int cardId)
    {
        this.cardId = cardId;
    }
    public override void excute()
    {
        
    }
}
