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
        return (int)Player.PlayerState.Runing;
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

        if (Input.GetKey(KeyCode.A))
        {
            m_Player.transform.position += new UnityEngine.Vector3(0.0f, 0.0f, 0.5f) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_Player.transform.position -= new UnityEngine.Vector3(0.0f, 0.0f, 0.5f) * Time.deltaTime;

        }
    }

    public void OnFixedUpdate()
    {
    }

    public void OnLateUpdate()
    {
    }

    #endregion
}