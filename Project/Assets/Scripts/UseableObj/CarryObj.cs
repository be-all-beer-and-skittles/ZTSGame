using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObj : UseableObjBase
{
    public Transform carryPos;
    bool isCarryed = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.isUse && !isCarryed)
        {
            OnCarry();
        }
    }

    void OnCarry()
    {
        this.gameObject.transform.position = carryPos.position;
        this.gameObject.transform.rotation = carryPos.rotation;
    }

    public void setIsCarryed(bool isCarryed)
    {
        this.isCarryed = isCarryed;
    }
}
