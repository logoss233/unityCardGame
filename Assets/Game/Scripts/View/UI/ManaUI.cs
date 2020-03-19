using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ManaUI : MonoBehaviour
{
    public static ManaUI instance;
    private void Awake()
    {
        ManaUI.instance = this;
    }

    public Text text;
    public int mana
    {
        set
        {
            text.text = value.ToString();
        }
    }
    

}
