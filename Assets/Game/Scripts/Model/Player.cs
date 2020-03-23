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
                drawDeck = discardDeck;
                discardDeck.Clear();
                canDraw = true;
            }
        }
        if (canDraw)
        {
            var card = drawDeck[0];
            drawDeck.RemoveAt(0);
            drawDeck.Add(card);
            sc.add(new DrawACardCmd(card.id));
        }
    }
} 