using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IDCtl : MonoBehaviour
{
    private static IDCtl _instance;
    public static IDCtl instance{
        get{return IDCtl._instance ;}
    }
    private void Awake()
    {
        IDCtl._instance = this;
    }
    //======

    private int currentId = 0;
    public int getId()
    {
        this.currentId += 1;
        return this.currentId;
    }
    
    //CardModel
    Dictionary<int,Card> cardDict=new Dictionary<int,Card>();
    public void addCard(Card card)
    {
        this.cardDict.Add(card.id, card);
    }
    public Card getCard(int id)
    {
        return this.cardDict[id];
    }
    
    //CardView
    Dictionary<int, CardView> cardViewDict = new Dictionary<int, CardView>();
    public void addCardView(CardView cardView)
    {
        if (this.cardViewDict.ContainsKey(cardView.id))
        {
            this.cardViewDict.Remove(cardView.id);
        }
        this.cardViewDict.Add(cardView.id, cardView);
    }
    public CardView getCardView(int id)
    {
        return this.cardViewDict[id];
    }


    public Dictionary<int, Actor> actorModelDic = new Dictionary<int, Actor>();
    public void addActorModel (Actor actorModel)
    {
        this.actorModelDic.Add(actorModel.id, actorModel);
    }
    public Actor getActorModel(int id)
    {
        return this.actorModelDic[id];
    }



    public Dictionary<int, ActorView> actorViewDic = new Dictionary<int, ActorView>();
    public void addActorView(ActorView actorView)
    {
        this.actorViewDic.Add(actorView.id, actorView);
    }
    public ActorView getActorView(int id)
    {
        return this.actorViewDic[id];
    }
}
