using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdCtl : MonoBehaviour,IAdd
{
    public static CmdCtl I;
    private void Awake()
    {
        CmdCtl.I = this;
    }
    public List<Cmd> cmdList = new List<Cmd>();

    

    public void add(Cmd command)
    {
        this.cmdList.Add(command);
        if (!this.isPlaying)
        {
            this.playCommand();
        }
    }
    public bool isPlaying = false;//是否正在播放
    //正在播放的commmand
    Cmd playingCommand;



    //播放最前面的command
    public void playCommand()
    {
        if (this.cmdList.Count == 0)
        {
            return;
        }
        var command = this.cmdList[0];
        this.cmdList.RemoveAt(0);
        this.playingCommand = command;
        this.isPlaying = true;
        command.finishHandler = this.onCommandComplete;
        command.excute();
    }
    private void onCommandComplete()
    {
        this.playingCommand = null;
        this.isPlaying = false;
        //检查下一个
        this.playCommand();
    }
    
    private void Update()
    {
        if(this.isPlaying && this.playingCommand!=null)
        {
            this.playingCommand.update();
        }
    }
}
