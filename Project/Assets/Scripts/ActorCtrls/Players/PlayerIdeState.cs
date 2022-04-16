using UnityEngine;
using System.Collections;

public class PlayerIdeState : IState
{
    Player m_Player = null;
    public PlayerIdeState(Player player)
    {
        m_Player = player;
    }
    #region IState 成员

    public int GetStateID()
    {
        return (int)Player.EPlayerState.Ide;
    }

    public void OnEnter(GameStateMachine stateMachine, IState prevState, object param1, object param2)
    {
        Debug.Log("进入待机状态 上次的状态为 ：" + prevState);
    }

    public void OnLeave(IState nextState, object param1, object param2)
    {
        Debug.Log("退出待机状态 下次的状态为 ：" + nextState);
    }

    public void OnUpdate()
    {
        //可以添加待机动画，找一个就行

    }

    public void OnFixedUpdate()
    {
    }

    public void OnLateUpdate()
    {
    }

    #endregion
}