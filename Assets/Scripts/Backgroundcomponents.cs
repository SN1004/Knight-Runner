using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundcomponents : MonoBehaviour
{
    private Vector3 ComponentPos;
    private Transform Camera;

    void Start()
    {
        Camera = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!Camera)
        {
            return;
        }
        ComponentPos = transform.position;
        ComponentPos.x = Camera.position.x;
        ComponentPos.y = Camera.position.y;
        transform.position = ComponentPos;
    }
}

