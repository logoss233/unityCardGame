using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAniCtl : MonoBehaviour
{
    public static EffectAniCtl instance;
    private void Awake()
    {
        EffectAniCtl.instance = this;
    }
    public void playAni(GameObject ani,Vector3 position)
    {
        Instantiate(ani);
        ani.transform.position = position;
    }
    
}
