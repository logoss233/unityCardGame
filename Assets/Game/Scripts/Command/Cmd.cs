using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public abstract class Cmd 
{
    public Action finishHandler;
    protected List<Cmd> runningCommand = new List<Cmd>();

    /// <summary>
    /// 运行一个子Command
    /// </summary>
    protected void run(Cmd command,Action finishAction)
    {
        this.runningCommand.Add(command);
        command.finishHandler = () =>
        {
            this.runningCommand.Remove(command);
            if (finishAction != null)
            {
                finishAction();
            }
        };
        command.excute();
    }
    /// <summary>
    /// 自身逻辑
    /// </summary>
    public abstract void excute();

    /// <summary>
    /// 结束自己
    /// </summary>
    public void finish()
    {
        if (this.finishHandler!=null)
        {
            this.finishHandler();
            this.finishHandler = null;
        }
    }

    public void update()
    {
        for(var i = this.runningCommand.Count - 1; i >= 0; i--)
        {
            var command = this.runningCommand[i];
            command.update();
        }
        this.onUpdate();
    }
    public virtual void onUpdate()
    {

    }
}
