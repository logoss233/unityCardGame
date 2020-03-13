using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class CardView : MonoBehaviour
{
    //=======显示卡的前面或者背面
    public GameObject cardFace;
    public GameObject cardBack;
    private bool _isFace = true;
    public bool isFace
    {
        get { return this._isFace; }
        set
        {
            this._isFace = value;
            this.cardFace.SetActive(value);
            this.cardBack.SetActive(!value);
        }
    }
    //======
    public PlayMakerFSM playerMakerFsm;
    private void Awake()
    {
        
    }
    

    public string state
    {
        get
        {
            return playerMakerFsm.ActiveStateName;
        }
    }

}
