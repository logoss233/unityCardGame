using UnityEngine;
using System.Collections;

public class UseCardCommand : Command
{
    int cardId;
    public UseCardCommand(int cardId)
    {
        this.cardId = cardId;
    }
    public override void excute()
    {
        
    }
}
