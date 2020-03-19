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
    public List<Card> hand = new List<Card>();
    public List<Card> drawDeck = new List<Card>();
    public List<Card> discardDeck = new List<Card>();

    
    public void drawACard()
    {

    }
} 