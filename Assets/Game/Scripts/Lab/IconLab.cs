using UnityEngine;
using System.Collections;

public class IconLab : MonoBehaviour
{
    public static IconLab instance;
    private void Awake()
    {
        IconLab.instance = this;
    }

    public Sprite hit;
    public Sprite doubleHit;

}
