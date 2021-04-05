using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Vector3 offset;
    Vector3 cameraPos;
    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        offset = Camera.main.transform.position - player.transform.position;
        cameraPos = Camera.main.transform.position;
    }

    private void Update()
    {
        cameraPos.z = player.transform.position.z + offset.z;
        cameraPos.y = player.transform.position.y + offset.y;
        cameraPos.x = player.transform.position.x + offset.x;
        Camera.main.transform.position = cameraPos;
    }
}
