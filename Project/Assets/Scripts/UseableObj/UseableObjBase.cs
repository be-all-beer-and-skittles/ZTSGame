using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseableObjBase : MonoBehaviour
{
    // Start is called before the first frame update
    bool isUse = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isUse = true;
        }
    }
}
