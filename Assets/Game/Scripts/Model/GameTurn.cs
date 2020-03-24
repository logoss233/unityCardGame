using UnityEngine;
using UnityEditor;
using System;

public class GameTurn:MonoBehaviour
{
    public static GameTurn I;
    public event Action<State> stateChangeEvent;
    private void Awake()
    {
        GameTurn.I = this;
    }
    public enum State
    {
        None,
        playerTurnBegin,
        playerTurn,
        playerWaitForEnd,
        playerTurnEnd,
        enemyTurnBegin,
        enemyTurn,
        enemyTurnEnd,
        
    }
    private State _state;
    public State state
    {
        get
        {
            return this._state;
        }
        set
        {
            if (this._state == value)
            {
                return;
            }
            //退出事件
           if (this._state == State.playerTurn)
            {

            }else if (this._state == State.enemyTurn)
            {

            }
            this._state = value;

            //进入事件
            switch (value)
            {
                case State.playerTurnBegin:
                    //玩家抽3张牌
                    Player.I.mana = 3;
                    CmdCtl.I.add(new UpdateManaCmd(Player.I.mana));
                    Player.I.drawACard(CmdCtl.I);
                    Player.I.drawACard(CmdCtl.I);
                    Player.I.drawACard(CmdCtl.I);
                    Player.I.drawACard(CmdCtl.I);
                    Player.I.drawACard(CmdCtl.I);
                    break;
                case State.playerTurnEnd:
                    //丢弃所有卡牌
                    Player.I.disCardAll(CmdCtl.I);
                    this.state = State.enemyTurnBegin;
                    break;
                case State.enemyTurnBegin:
                    this.state = State.enemyTurn;
                    break;
                case State.enemyTurn:
                    this.state = State.enemyTurnEnd;
                    break;
                case State.enemyTurnEnd:

                    this.state = State.playerTurnBegin;
                    break;

            }
            if (this.stateChangeEvent != null)
            {
                this.stateChangeEvent(value);
            }

        }
    }

    private void Update()
    {
        switch (this.state)
        {
            case State.playerTurnBegin:
                if (CmdCtl.I.isPlaying == false)
                {
                    state = State.playerTurn;
                }
                break;

            case State.playerWaitForEnd:
                if (CmdCtl.I.isPlaying == false)
                {
                    state = State.playerTurnEnd;
                }
                break;
            
        }
    }

}