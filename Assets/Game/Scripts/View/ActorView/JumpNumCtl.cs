using UnityEngine;
using System.Collections;

public class JumpNumCtl : MonoBehaviour
{
    public static JumpNumCtl instance;
    private void Awake()
    {
        JumpNumCtl.instance = this;  
    }
    public GameObject damageNumberPrefab;
    public void jumpDamage(int num,Vector3 position)
    {
        var go= Instantiate(this.damageNumberPrefab,transform);
        
        go.transform.position = position;
        var jumpNum = go.GetComponent<DamageNumber>();
        jumpNum.init(num);

    }
}
