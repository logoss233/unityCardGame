﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class CardView : MonoBehaviour
{
    public static CardView mousePosCard;//纯粹的 当前鼠标在哪张卡上
   


    //======
    public PlayMakerFSM playerMakerFsm;

    //idle变量
    public Vector3 targetPos=Vector3.zero;
    public Vector3 targetRotiton=new Vector3(0,0,0);
    public Vector3 targetScale=new Vector3(1,1,1);
    public int orderInhand = 0; //在手牌中的顺序

    public bool needTarget = true;//是否需要指定对象释放

    public string state
    {
        get
        {
            return playerMakerFsm.ActiveStateName;
        }
    }
    public void init()
    {
       
    }

    private void Update()
    {
       

    }


    public void onPointEnter()
    {
         CardView.mousePosCard = this;
    }
    public void onPointExit()
    {
        if (CardView.mousePosCard == this)
        {
            CardView.mousePosCard = null;
        }
    }
}
