using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequenceCmd : Cmd,IAdd
{
    public List<Cmd> commandList = new List<Cmd>();
    public int index = 0;
    public override void excute()
    {
        this.playCommand();
    }

    public void add(Cmd command)
    {
        this.commandList.Add(command);
    }
    private void playCommand()
    {
        if (this.index < this.commandList.Count)
        {
            var command = this.commandList[this.index];
            this.index += 1;
            this.run(command, this.playCommand);
        }
        else
        {
            this.finish();
        }
    }
}
