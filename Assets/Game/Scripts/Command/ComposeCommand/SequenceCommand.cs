using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequenceCommand : Command
{
    public List<Command> commandList = new List<Command>();
    public int index = 0;
    public override void excute()
    {
        this.playCommand();
    }

    public void add(Command command)
    {
        this.commandList.Add(command);
    }
    private void playCommand()
    {
        if (this.index < this.commandList.Count)
        {
            var command = this.commandList[this.index];
            this.index += 1;
            this.runCommand(command, this.playCommand);
        }
        else
        {
            this.finish();
        }
    }
}
