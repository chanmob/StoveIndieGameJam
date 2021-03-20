using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tail : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public Vector3 dir;

    private void Update()
    {
        moveUpdate();
    }

    void moveUpdate()
    {
        if (transform.parent != null)
        {
            dir = gameObject.transform.parent.transform.position - gameObject.transform.position;
            dir.Normalize();
            gameObject.transform.Translate(dir * moveSpeed * Time.deltaTime);
        }
    }
}


