using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 CamTargetPos = new Vector3();
    private Transform Player;

    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = this.Player.transform.position + CamTargetPos;
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
        // 这两个位置不能反哦
        Quaternion targetRotation = Quaternion.LookRotation(Player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}