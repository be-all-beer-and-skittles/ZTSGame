using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformOBJ : UseableObjBase
{
    // Start is called before the first frame update
    public bool isRoation;
    public MsgBoard msgBoard;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isUse)
        {
            if (isRoation)
            {
                OnRoation();
            }
            else
            {
                OnMove();
            }
        }
    }
    void OnRoation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, 0, 0), 0.05f);
        msgBoard.canPass = true;

    }
    void OnMove()
    {
        this.transform.position= GameObject.Find("DingZiPos").transform.position;
        msgBoard.canPass = true;
    }
}
