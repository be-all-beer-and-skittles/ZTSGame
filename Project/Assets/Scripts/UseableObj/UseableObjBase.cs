using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseableObjBase : MonoBehaviour
{
    protected Player player =new Player();

    // Start is called before the first frame update
    protected bool isUse = false;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            isUse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isUse = false;
        }
    }
}
