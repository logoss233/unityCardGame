using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitEffect : MonoBehaviour
{
    public Image image;
    float HIT_TIME=0.2f;
    float timer=0.2f;
    public void play()
    {
        image.material.EnableKeyword("HITEFFECT_ON");
        image.material.EnableKeyword("SHAKEUV_ON");
        this.timer = this.HIT_TIME;

    }
    private void Update()
    {
        if (this.timer > 0)
        {
            this.timer -= Time.deltaTime;
            if (this.timer <= 0)
            {
                this.complete();
            }
        }
    }
    private void complete()
    {
        image.material.DisableKeyword("HITEFFECT_ON");
        image.material.DisableKeyword("SHAKEUV_ON");
    }
}
