using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitCmd : Cmd
{
    public WaitCmd(float time)
    {
        this.time = time;
    }

    float time = 1f;
    float timer=0;
    public override void excute()
    {
        this.timer = 0;
    }

    public override void onUpdate()
    {
        this.timer += Time.deltaTime;
        if (this.timer >= this.time)
        {
            this.finish();
        }
    }
}
