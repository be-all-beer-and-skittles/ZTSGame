using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    GameStateMachine playerGameStateMachine = new GameStateMachine();

    public Transform childTransform;
    public float jumpheight = 0.18f;

    public float moveForce;//移动 力
    public float jumpForce;//起跳 力
    public float jumpMoveForce;//起跳 力
    public bool isJump = false;

    public Rigidbody rigidbody;

    public enum EPlayerState
    {

        Ide = 0,//待机
        Runing = 1,//移动
        Jump = 2,//移动
    }

    void Awake()
    {
        //注册所有状态//
        playerGameStateMachine.RegistState(new PlayerIdeState(this)); //注册待机状态//
        playerGameStateMachine.RegistState(new PlayerRuningState(this)); //注册行走状态//
        playerGameStateMachine.RegistState(new PlayerJumpState(this)); //注册行走状态//

        playerGameStateMachine.SwitchState((int)EPlayerState.Ide, null, null);
    }

    void Update()
    {
        if (playerGameStateMachine.GetCurState() != null)
        {
            currentstate = (EPlayerState)playerGameStateMachine.GetCurStateID();
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

    private EPlayerState currentstate = EPlayerState.Ide;

    void playStateCtrl()
    {
        //Debug.Log("isjump"+ isJump);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
            StopCoroutine("forceToMove");
            StartCoroutine("forceToMove");
        }
        if (isJump)
        {
           playerGameStateMachine.SwitchState((int)EPlayerState.Jump, null, null);
        }
        else
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                playerGameStateMachine.SwitchState((int)EPlayerState.Runing, null, null);
            }
            else
            {
                playerGameStateMachine.SwitchState((int)EPlayerState.Ide, null, null);
            }
        }

    }
    IEnumerator forceToMove()
    {
        yield return new WaitForSeconds(1.0f);
        isJump = false;
    }


}