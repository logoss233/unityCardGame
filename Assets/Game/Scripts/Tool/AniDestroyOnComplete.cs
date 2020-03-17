using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniDestroyOnComplete : MonoBehaviour
{
    Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
        
    }
    private void Update()
    {
        AnimatorStateInfo info = ani.GetCurrentAnimatorStateInfo(0);
        
        if (info.normalizedTime >= 1.0f)
        {
            GameObject.Destroy(gameObject);
        }

    }
}
