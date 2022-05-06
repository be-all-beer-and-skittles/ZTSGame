using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MsgUI : MonoBehaviour
{
    public Button nextBtn;
    public Sprite[] TextSprite;
    public Image TextImg;
    public Sprite endImg;
    public Sprite toEndImg;
    GameController gameController = new GameController();
    bool OnEnd = false;
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
            TextImg.sprite = TextSprite[(int)gameController.nowLevel - 1];
            this.gameObject.SetActive(false);
        }
        else
        {
            OnEnd = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (OnEnd)
        {
            this.gameObject.GetComponent<Image>().sprite = endImg;
            this.gameObject.GetComponent<Image>().SetNativeSize();
            TextImg.gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnGameRestart();
            }
            else if(Input.GetKeyDown(KeyCode.Q))
            {
                OnGameEnd();
            }
        }
        if (gameController.nowLevel == ELevel.Level5)
        {
            nextBtn.GetComponent<Image>().sprite = toEndImg;
            this.gameObject.GetComponent<Image>().SetNativeSize();

        }
    }
    void OnGameEnd()
    {
        gameController.CloseGame();

    }
    void OnGameRestart()
    {
        SceneManager.LoadScene(0);
        gameController.DestoryThis();
    }
}

