using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndTurnBtn : MonoBehaviour
{
    public Button button;
    public void init()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(this.onClick);

        GameTurn.I.stateChangeEvent += state =>
        {
            if (state == GameTurn.State.playerTurn)
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        };
    }
    public void onClick()
    {
        if (GameTurn.I.state == GameTurn.State.playerTurn)
        {
            GameTurn.I.state = GameTurn.State.playerWaitForEnd;
        }
    }
}
