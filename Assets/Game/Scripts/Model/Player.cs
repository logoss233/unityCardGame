using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Player:MonoBehaviour
{
    public static Player I;
    private void Awake()
    {
        Player.I = this;
    }

    public int mana = 10;
    public Actor playerActor;
    [SerializeField]
    public List<Card> hand = new List<Card>();
    public List<Card> drawDeck = new List<Card>();
    public List<Card> discardDeck = new List<Card>();

    
    public void drawACard(IAdd sc)
    {
        var canDraw = false;
        if (drawDeck.Count > 0)
        {
            canDraw = true;
            
        }
        else
        {
            if (discardDeck.Count > 0)
            {    
                drawDeck.AddRange(discardDeck);
                discardDeck.Clear();
                canDraw = true;
            }
        }
        if (canDraw)
        {
            var card = drawDeck[0];
            drawDeck.RemoveAt(0);
            hand.Add(card);
            sc.add(new DrawACardCmd(card.id));
        }

    }
    
    public void disCard(IAdd sc,Card card)
    {
        this.hand.Remove(card);
        this.discardDeck.Add(card);

        sc.add(new DiscardCmd(card.id));
    }
    public void disCardAll(IAdd sc)
    { 

        for(var i = this.hand.Count - 1; i >=0; i--)
        {
            
            var card = this.hand[i];
            this.disCard(sc,card);
        }   
    }

    private void OnGUI()
    {
        string str=string.Format("抽牌堆{0:D},\n手牌数{1:D},\n弃牌堆{2:D},\n回合\n{3:S}",  this.drawDeck.Count, this.hand.Count, this.discardDeck.Count,GameTurn.I.state.ToString());

        GUI.Box(new Rect(10, 10, 100, 90),str);

 
    }

} 