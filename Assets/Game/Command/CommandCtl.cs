using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCtl : MonoBehaviour
{
    public static CommandCtl instance;
    private void Awake()
    {
        CommandCtl.instance = this;
    }
    public List<Command> commandList = new List<Command>();

    

    public void addCommand(Command command)
    {
        this.commandList.Add(command);
        if (!this.isPlaying)
        {
            this.playCommand();
        }
    }
    public bool isPlaying = false;//是否正在播放
    //正在播放的commmand
    Command playingCommand;



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
