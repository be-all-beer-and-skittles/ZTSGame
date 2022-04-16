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
        isJump = true;
        m_Player.characterController.stepOffset = 0.3f;
        Debug.Log("进入跳跃状态 上次的状态为 ：" + prevState);
    }

    public void OnLeave(IState nextState, object param1, object param2)
    {
        m_Player.characterController.stepOffset = 0f;

        Debug.Log("退出跳跃状态 下次的状态为 ：" + nextState);
    }

    public void OnUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(new Vector3(0, 0, m_Player.transform.position.z), true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(new Vector3(m_Player.transform.position.x, 0, 0), false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(new Vector3(0, 0, m_Player.transform.position.z), false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(new Vector3(m_Player.transform.position.x, 0, 0), true);
        }
    }

    public void OnFixedUpdate()
    {
        Jump();
    }

    public void OnLateUpdate()
    {
    }

    #endregion
    void Jump()
    {
        m_Player.jumpSpeed += m_Player.gravity * Time.fixedDeltaTime;
        if (m_Player.gameObject.transform.position.y <= m_Player.childTransform.position.y + 0.05f && m_Player.jumpSpeed < 0)
        {
            m_Player.jumpSpeed = 0;
            m_Player.childTransform.position = m_Player.transform.position;


            if (m_Player.childTransform.position == m_Player.transform.position)
            {
                Debug.Log("end jump");
                isJump = false;
                m_Player.jumpCB();
            }
        }

        m_Player.childTransform.Translate(new Vector3(0, m_Player.jumpSpeed, 0) * Time.fixedDeltaTime);
    }
    public void Move(Vector3 direction, bool Positive)
    {
        m_Player.characterController.Move(direction * (Positive ? m_Player.maxMoveSpeed : -m_Player.maxMoveSpeed) * Time.deltaTime);
    }
}