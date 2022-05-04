using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgUI : MonoBehaviour
{
    public Button nextBtn;
    GameController gameController = new GameController();
    // Start is called before the first frame update
    void Start()
    {

        nextBtn.onClick.AddListener(NextBtnOnClick);
        gameController = GameObject.Find("GameCtrler").GetComponent<GameController>();

    }

    private void NextBtnOnClick()
    {
        if (gameController.nowLevel!= ELevel.Level5)
        {
            gameController.ChangeScence((ELevel)((int)gameController.nowLevel + 1));
            this.gameObject.SetActive(false);
        }
        else
        {
            OnGameEnd();
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGameEnd()
    {
        Debug.Log("OnGameEnd");

    }
}
