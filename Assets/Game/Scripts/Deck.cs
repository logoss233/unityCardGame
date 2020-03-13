using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Deck : MonoBehaviour
{
    public int count = 1;
    public float hightPerCount = 0.05f;
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -count * hightPerCount - 0.03f);
        }
        
    }
}
