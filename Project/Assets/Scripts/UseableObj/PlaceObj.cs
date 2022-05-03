using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObj : UseableObjBase
{
    public Transform placePos;
    public GameObject carryObj;
    public MsgBoard msgBoard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (this.isUse)
        {
            OnPlace();
        }
    }
    void OnPlace()
    {
        carryObj.transform.position = placePos.position;
        carryObj.transform.rotation = placePos.rotation;
        carryObj.GetComponent<CarryObj>().setIsCarryed(true);
        msgBoard.canPass = true;

    }
}
