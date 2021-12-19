using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 camPos;
    private Transform player;

    [SerializeField]
    private float MinX, MaxX, MinY, MaxY;
            
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
        {
            return;
        }
        camPos = transform.position;
        camPos.x = player.position.x;
        camPos.y = player.position.y;

        if (camPos.x < MinX)
        {
            camPos.x = MinX;
        }
        if (camPos.x > MaxX)
        {
            camPos.x = MaxX;
        }
        if (camPos.y < MinY)
        {
            camPos.y = MinY;
        }
        if (camPos.y > MaxY)
        {
            camPos.y = MaxY;
        }

        transform.position = camPos;
    }
}

