using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public Text text;
    public float hSpeed=100;
    public float vSpeed=800;
    public float gravity=500;
    public float life = 2;
    public void init(int number)
    {
        this.text.text = number.ToString();
        this.hSpeed = Random.Range(-100f, 100f);
    }

    void Update()
    {
        transform.position += new Vector3(hSpeed * Time.deltaTime, vSpeed*Time.deltaTime, 0) ;
        this.vSpeed -= this.gravity * Time.deltaTime;
        this.life -= Time.deltaTime;
        if (this.life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
