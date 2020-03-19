using UnityEngine;
using UnityEditor;

public class UpdateManaCmd : Cmd
{
    public int mana;
    public UpdateManaCmd(int mana)
    {
        this.mana = mana;
    }
    public override void excute()
    {
        ManaUI.instance.mana = this.mana;
        this.finish();
    }
}