using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandView : MonoBehaviour
{
    private static HandView _instance;
    public static HandView instance
    {
        get
        {
            return HandView._instance;
        }
    }
    private void Awake()
    {
        HandView._instance = this;
    }
    private void Start()
    {
        
    }

    public List<CardView> cardViewList = new List<CardView>();
    public Transform centerPoint;
    public GameObject CardViewPrefab;
    public Transform cardPlace;
    public Transform drawCardFromPos;
    public Transform drawCardEndPos;
    public Transform commitPoint;
   
   

    public void drawCard(int cardId)
    {
        var cardViewGO = Instantiate(this.CardViewPrefab);
        var cardView = cardViewGO.GetComponent<CardView>();
        this.cardViewList.Add(cardView);
        cardView.init(cardId);
       
        //重置手牌顺序
        for(var i = 0; i < this.cardViewList.Count; i++)
        {
            var c = this.cardViewList[i];
            c.orderInhand = i;
        }
        //重新计算手牌的位置
        this.calculateCardPos();
    }


    //计算手中卡牌的位置和角度

    public void calculateCardPos()
    {
        //普通状态
       
        var num = this.cardViewList.Count;
        var middleNum = (float)(num - 1) / 2;

        for (int i = 0; i < this.cardViewList.Count; i++)
        {
            //计算位置
            var offX = (i - middleNum) * 100;
            var x = this.centerPoint.position.x + offX;
            var offY = 50 - Mathf.Abs(i - middleNum) * 20;
            var y = this.centerPoint.position.y + offY;
            CardView cardView = this.cardViewList[i];
            cardView.targetPos = new Vector3(x, y, this.centerPoint.position.z);
            //计算旋转
            var angle = -(i - middleNum) * 5;
            cardView.targetRotiton = new Vector3(0, 0, angle);
        }
    }

    public void removeCardView(CardView cardView)
    {
        this.cardViewList.Remove(cardView);
        this.calculateCardPos();
    }


  
    //正在操作的卡牌，同一时间只能操作一个卡牌
    public CardView controlCard;
    
    private void Update()
    {
        if (this.controlCard==null)
        {
            if (CardView.mousePosCard != null && CardView.mousePosCard.state == "idle")
            {

                this.chooseCard(CardView.mousePosCard);
            }
        }
    }
    void chooseCard(CardView cardView)
    {
        cardView.state = "point";
       
        this.controlCard = cardView;
    }
    public void cancelChoose()
    {
        this.controlCard = null;
    }

    
}
