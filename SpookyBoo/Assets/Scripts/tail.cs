﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tail : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public Vector3 pos, dir, des;
    public bool arrive = false, stop = true;
    public float padding;
    public GameObject parent, child;

    private void Update()
    {

        if (stop)
            moveUpdate();
        if (Math.Abs(parent.transform.position.x - transform.position.x) <= padding || Math.Abs(parent.transform.position.y - transform.position.y) <= padding)
            stop = false;
        else
            stop = true;
    }

    void moveUpdate()
    {
        pos = transform.position;
        dir = parent.transform.position - pos;
        dir.Normalize();
        gameObject.transform.Translate(dir * moveSpeed * Time.deltaTime);
        
//        stop = false;
    }

}