using UnityEngine;
using System.Collections;

public class PlayerRuningState : IState
{
    Player m_Player = null;


    public PlayerRuningState(Player player)
    {
        m_Player = player;
    }
    #region IState 成员

    public int GetStateID()
    {
        return (int)Player.EPlayerState.Runing;
    }

    public void OnEnter(GameStateMachine stateMachine, IState prevState, object param1, object param2)
    {

        Debug.Log("进入行走状态 上次的状态为 ：" + prevState);
    }

    public void OnLeave(IState nextState, object param1, object param2)
    {

        Debug.Log("退出行走状态 下次的状态为 ：" + nextState);
    }

    public void OnUpdate()
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

    public void OnFixedUpdate()
    {
    }

    public void OnLateUpdate()
    {
    }
    /// <summary>
    /// 人物移动方法
    /// </summary>
    /// <param name="direction">人物移动方向的向量</param>
    public void Move(Vector3 direction)
    {
        //m_Player.rigidbody.velocity = direction * Time.deltaTime * m_Player.moveForce;
        m_Player.transform.Translate(direction * Time.deltaTime);
    }
    #endregion
}