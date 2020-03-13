using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CheckCardBack : MonoBehaviour
{
    public Transform checkBackPoint;
    public GameObject cardFace;
    public GameObject cardBack;
    

    // Update is called once per frame
    void Update()
    {
        var arr=Physics.RaycastAll(Camera.main.transform.position, checkBackPoint.position - Camera.main.transform.position, 
            (checkBackPoint.position - Camera.main.transform.position).magnitude, LayerMask.GetMask("Card"));
        bool isHit = false;
        foreach(var item in arr)
        {
            if (item.transform == transform)
            {
                isHit = true;
                break;
            }
        }
        cardFace.SetActive(!isHit);
        cardBack.SetActive(isHit);
    }
}
