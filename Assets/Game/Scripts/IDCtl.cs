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
    Dictionary<int,Card> cardModelDict=new Dictionary<int,Card>();
    public void addCardModel(Card cardModel)
    {
        this.cardModelDict.Add(cardModel.id, cardModel);
    }
    public Card getCardModel(int id)
    {
        return this.cardModelDict[id];
    }
    
    //CardView
    Dictionary<int, CardView> cardViewDict = new Dictionary<int, CardView>();
    public void addCardView(CardView cardView)
    {
        this.cardViewDict.Add(cardView.id, cardView);
    }
    public CardView getCardView(int id)
    {
        return this.cardViewDict[id];
    }


    public Dictionary<int, ActorModel> actorModelDic = new Dictionary<int, ActorModel>();
    public void addActorModel (ActorModel actorModel)
    {
        this.actorModelDic.Add(actorModel.id, actorModel);
    }
    public ActorModel getActorModel(int id)
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
