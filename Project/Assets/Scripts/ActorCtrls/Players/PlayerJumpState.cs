using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : IState
{
    Player m_Player = null;
    bool isGround = true;
    int Groundcount = 0;
    bool canJumpMove;

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
        Groundcount = 0;
        canJumpMove = true;
        Debug.Log("进入跳跃状态 上次的状态为 ：" + prevState);
    }

    public void OnLeave(IState nextState, object param1, object param2)
    {

        Debug.Log("退出跳跃状态 下次的状态为 ：" + nextState);
    }

    public void OnUpdate()
    {
        if (canJumpMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Move(new Vector3(0, 0, m_Player.transform.position.z));
            }
            if (Input.GetKey(KeyCode.A))
            {
                Move(new Vector3(-m_Player.transform.position.x, 0, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                Move(new Vector3(0, 0, -m_Player.transform.position.z));
            }
            if (Input.GetKey(KeyCode.D))
            {
                Move(new Vector3(m_Player.transform.position.x, 0, 0));
            }
        }
    }

    public void OnFixedUpdate()
    {
        bool current = isGround;
        isGround = Physics.Raycast(m_Player.transform.position, new Vector3(0, -1, 0), 0.18f, 1 << 9);
        if (isGround != current)
        {
            Groundcount++;
        }
        if (Groundcount > 1)
        {
            m_Player.isJump = false;
        }

    }

    public void OnLateUpdate()
    {
    }

    #endregion

    void Jump()
    {
        m_Player.rigidbody.AddForce(Vector3.up * m_Player.jumpForce);
    }
    public void Move(Vector3 direction)
    {
        m_Player.rigidbody.AddForce(direction.normalized * (m_Player.moveForce/10));
        canJumpMove = false;
    }
}