using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAniLab : MonoBehaviour
{
    private static EffectAniLab _instance;
    public static EffectAniLab instance
    {
        get
        {
            return EffectAniLab._instance;
        }
    }
    private void Awake()
    {
        EffectAniLab._instance = this;
    }

    public GameObject blow;
    public GameObject claw;
    public GameObject absorb;
    public GameObject arrowSpecial;
    public GameObject defend;

}
