using UnityEngine;
using UnityEditor;

public class DiscardCmd : Cmd
{
    int cardId;
    public DiscardCmd(int cardId)
    {
        this.cardId = cardId;
    }
    public override void excute()
    {
        
        var cardView = IDCtl.instance.getCardView(cardId);
        cardView.state = "use";
        this.finish();
    }
}