using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOBJ : MonoBehaviour
{

    public bool isStratGame = true;
    GameController gameController = new GameController();

    private void Awake()
    {
        gameController = GameObject.Find("GameCtrler").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (isStratGame)
            {
                gameController.ChangeScence(ELevel.Level1);
            }
            else
            {
                gameController.CloseGame();
            }
        }
    }
}
