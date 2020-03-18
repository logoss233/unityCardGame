using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdCtl : MonoBehaviour
{
    public static CmdCtl instance;
    private void Awake()
    {
        CmdCtl.instance = this;
    }
    public List<Cmd> commandList = new List<Cmd>();

    

    public void addCommand(Cmd command)
    {
        this.commandList.Add(command);
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
        if (this.commandList.Count == 0)
        {
            return;
        }
        var command = this.commandList[0];
        this.commandList.RemoveAt(0);
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
