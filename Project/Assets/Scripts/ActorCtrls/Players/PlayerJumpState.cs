using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : IState
{
    Player m_Player = null;
    private float v_y;
    bool isJump;
    public PlayerJumpState(Player player)
    {
        m_Player = player;
    }
    #region IState 成员

    public int GetStateID()
    {
        return (int)Player.EPlayerState.Jump;
    }

    public void OnEnter(GameStateMachine stateMachine, IState prevState, object param1, object param2)
    {
        Jump();

        Debug.Log("进入跳跃状态 上次的状态为 ：" + prevState);
    }

    public void OnLeave(IState nextState, object param1, object param2)
    { 

        Debug.Log("退出跳跃状态 下次的状态为 ：" + nextState);
    }

    public void OnUpdate()
    {
    }

    public void OnFixedUpdate()
    {
    }

    public void OnLateUpdate()
    {
    }

    #endregion
    void Jump()
    {
        Debug.Log("Jump");
        m_Player.rigidbody.AddForce(Vector3.up * m_Player.jumpForce);
    }

}