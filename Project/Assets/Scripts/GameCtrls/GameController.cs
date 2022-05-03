using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// levelNames: Menu \level1\level2\level3\level4\level5
/// 这里是需求意义上的关卡名，实际除Menu外都在同一个场景中
/// </summary>
/// 
public enum ELevel 
{
    Menu = 0,
    Level1,
    Level2,
    Level3,
    Level4,
    Level5
}

public class GameController : MonoBehaviour
{
    public ELevel nowLevel = ELevel.Menu;
    public string[] playersPos;
    // Start is called before the first frame update
    GameObject player;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScence(ELevel level)
    {
        Debug.Log("当前场景：" + level.ToString());

        if (nowLevel == ELevel.Menu)
        {
            SceneManager.LoadScene((int)level);
        }
        else
        {
            GameObject.Find("Player").transform.position =  GameObject.Find(playersPos[(int)level - 1]).transform.position;
        }
        nowLevel = level;

    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
