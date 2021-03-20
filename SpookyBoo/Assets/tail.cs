using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tail : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public Vector3 dir;
    public bool arrive = false, stop = true;
    public float padding;

    Vector3 nextTailPos;
    int i = 0;
    private void Update()
    {
        moveUpdate();
    }

    void moveUpdate()
    {
        
        if (transform.parent != null && arrive && i == 0)
        {
            dir = gameObject.transform.parent.position - gameObject.transform.position;
            dir.Normalize();
            if (stop)
            {
                gameObject.transform.Translate(dir * moveSpeed * Time.deltaTime);
            }
            if (gameObject.transform.parent.position.x - gameObject.transform.position.x <= padding && gameObject.transform.parent.position.y - gameObject.transform.position.y <= padding)
                stop = false;
            else
                stop = true;
        }
        i++;
        if (i > 4)
            i = 0;

    }
}


