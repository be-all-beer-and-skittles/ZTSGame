using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgBoard : UseableObjBase
{
    public GameObject msgUI;
    public bool canPass = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isUse && canPass)
        {
            ShowMsg();
            canPass = false;
        }
    }

    void ShowMsg()
    {
        msgUI.SetActive(true);
    }
}
