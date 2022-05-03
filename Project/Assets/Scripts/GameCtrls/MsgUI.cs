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
       gameController.ChangeScence((ELevel)((int)gameController.nowLevel+1));
       this.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
