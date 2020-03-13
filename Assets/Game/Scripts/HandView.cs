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


    public List<CardView> cardViewList = new List<CardView>();
    public Transform centerPoint;
    public GameObject CardViewPrefab;
    public Transform cardPlace;
    private void Update()
    {
        
    }
    //计算卡牌位置
    private List<CardView> calcuList = new List<CardView>();
    private void calculateCardPos()
    {
        
        calcuList.Clear();
        for(int i = 0; i < this.cardViewList.Count; i++)
        {
            CardView cardView = this.cardViewList[i];
            if (cardView.state != "draw")
            {
                calcuList.Add(cardView);
            }
        }

        var num = this.calcuList.Count;
        var middleNum = num / 2;
        for (int i = 0; i < this.calcuList.Count; i++)
        {
            var offX = (i - middleNum) * 2;
            var x = this.centerPoint.position.x + offX;
            CardView cardView = this.cardViewList[i];
            cardView.transform.position = new Vector3(x, this.centerPoint.position.y, this.centerPoint.position.z);

        }
    }

    public void drawCard()
    {
        var cardViewGO = Instantiate(this.CardViewPrefab, cardPlace);
        var cardView = cardViewGO.GetComponent<CardView>();
        this.cardViewList.Add(cardView);
    }
}
