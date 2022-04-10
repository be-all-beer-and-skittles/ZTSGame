using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    GameStateMachine playerGameStateMachine = new GameStateMachine();
    public enum PlayerState
    {

        Ide = 0,//待机
        Runing = 1,//移动
    }

    void Awake()
    {
        //注册所有状态//
        playerGameStateMachine.RegistState(new PlayerIdeState(this)); //注册待机状态//
        playerGameStateMachine.RegistState(new PlayerRuningState(this)); //注册行走状态//

        playerGameStateMachine.SwitchState((int)PlayerState.Ide, null, null);
    }

    void Update()
    {
        if (playerGameStateMachine.GetCurState() != null)
        {
            currentstate = (PlayerState)playerGameStateMachine.GetCurStateID();
        }
        playerGameStateMachine.OnUpdate();
        playStateCtrl();

    }

    void FixedUpdate()
    {
        playerGameStateMachine.OnFixedUpdate();
    }

    void LateUpdate()
    {
        playerGameStateMachine.OnLateUpdate();
    }

    private PlayerState currentstate = PlayerState.Ide;

    void playStateCtrl()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            playerGameStateMachine.SwitchState((int)PlayerState.Runing, null, null);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            //add jump
        }
        else
        {
            playerGameStateMachine.SwitchState((int)PlayerState.Ide, null, null);
        }
    }



}