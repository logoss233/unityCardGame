using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public static CardView mousePosCard;//纯粹的 当前鼠标在哪张卡上
    public int id;
    public Card cardModel;

    public Text nameText;
    public Text descriptionText;
    public Image icon;
    public Text costText;
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
        set
        {
            playerMakerFsm.Fsm.SetState(value);
        }
    }
    public void init(int id)
    {
        this.id = id;
        IDCtl.instance.addCardView(this);
        var cardModel = IDCtl.instance.getCard(id);
        this.cardModel = cardModel;
        this.nameText.text = cardModel.name;
        this.descriptionText.text = cardModel.description;
        this.icon.sprite = cardModel.icon;
        this.costText.text = cardModel.cost.ToString();
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

    //绿色背光效果
    public GameObject backLight;
    private bool _isShowBackLight = false;
    public bool isShowBackLight
    {
        get { return this._isShowBackLight; }
        set
        {
            if (_isShowBackLight == value)
            {
                return;
            }
            this._isShowBackLight = value;
            backLight.SetActive(value);
        }
    }

    //黄色背光效果
    public GameObject yellowBackLight;
    private bool _isShowYellowBackLight = false;
    public bool isShowYellowBackLight
    {
        get { return this._isShowYellowBackLight; }
        set
        {
            if (this._isShowYellowBackLight == value)
            {
                return;
            }
            this._isShowYellowBackLight = value;
            this.yellowBackLight.SetActive(value);
        }
    }
}
