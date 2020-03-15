using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCtl : MonoBehaviour
{
    public static ArrowCtl instance;

    public List<Transform> arrowList = new List<Transform>();
    public GameObject baseArrow;
    public Transform arrowPlace;
    
    private void Awake()
    {
        ArrowCtl.instance = this;
    }
    private void Start()
    {
        //生成箭头
        this.arrowList.Add(baseArrow.transform);
        for(var i = 0; i < 19;i++)
        {
            var arrow = Instantiate(baseArrow,this.arrowPlace);
            arrowList.Add(arrow.transform);
        }
        //箭头大小和隐藏
        baseArrow.SetActive(false);
        for(var i = 0; i < 20; i++)
        {
            var s = (float)i / 19*0.8f+0.2f;
            this.arrowList[i].localScale = new Vector3(s, s, 1);
        }
    }
    public void open()
    {
        arrowPlace.gameObject.SetActive(true);
    }
    public void close()
    {
        arrowPlace.gameObject.SetActive(false);
    } 
    public void set(Vector2 startPos,Vector2 endPos)
    {
        //计算位置
        var ctlAPos = Vector2.zero;
        var ctlBPos = Vector2.zero;
        ctlAPos.x = startPos.x + (startPos.x - endPos.x) * 0.1f;
        ctlAPos.y = endPos.y - (endPos.y - startPos.y) * 0.2f;
        ctlBPos.y = endPos.y + (endPos.y - startPos.y) * 0.3f;
        ctlBPos.x = startPos.x - (startPos.x - endPos.x) * 0.3f;
        for(var i = 0; i < 20; i++)
        {
            var t = (float)i / 19;
            var pos = startPos * (1 - t) * (1 - t) * (1 - t) + 3 * ctlAPos * t * (1 - t) * (1 - t) + 3 * ctlBPos * t * t * (1 - t) + endPos * t * t * t;
            this.arrowList[i].position = (Vector3)pos;
        }

        //计算方向
        for(var i = 0; i < 20; i++)
        {
            if (i == 0)
            {
                this.arrowList[i].eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                var current = this.arrowList[i];
                var last = this.arrowList[i - 1];
                var a = Vector2.SignedAngle(Vector2.up,current.position - last.position);
                current.rotation =Quaternion.Euler(new Vector3(0, 0, a));
            }
        }
    }
    
}
