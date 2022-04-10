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
        return (int)Player.PlayerState.Ide;
    }

    public void OnEnter(GameStateMachine stateMachine, IState prevState, object param1, object param2)
    {
        isUp = false;
        Debug.Log("进入待机状态 上次的状态为 ：" + prevState);
    }

    public void OnLeave(IState nextState, object param1, object param2)
    {
        Debug.Log("退出待机状态 下次的状态为 ：" + nextState);
    }

    bool isUp = true;
    public void OnUpdate()
    {
        //可以添加待机动画，找一个就行
        if (m_Player.transform.position.y >= 0.3)
        {
            isUp = false;
        }
        if (m_Player.transform.position.y <= 0.2)
        {
            isUp = true;
        }
        if (isUp)
        {
            m_Player.transform.position += new UnityEngine.Vector3(0.0f, 0.2f, 0.0f) * Time.deltaTime;
        }
        else
        {
            m_Player.transform.position -= new UnityEngine.Vector3(0.0f, 0.1f, 0.0f) * Time.deltaTime;
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