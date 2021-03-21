using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tail : MonoBehaviour
{
    public GameObject foodCreater;
    public float moveSpeed = 3.0f, speedUp = 1.2f;
    public Vector3 pos, dir, des;
    public bool arrive = false, stop = true;
    public float padding;
    public GameObject parent, child;
    DeadEvent deadEvent;

    SpeedEvent speed;
    void Start()
    {
        speed = new SpeedEvent();
        speed.onSpeed += new SpeedEvent.speedHandler(SpeedUpEvent);
        deadEvent = new DeadEvent();
    }


    private void FixedUpdate()
    {
        if (parent != null)
            if (parent.tag == "Player")
                padding = 0.8f;
        double a = Math.Pow(parent.transform.position.x - transform.position.x, 2) + Math.Pow(parent.transform.position.y - transform.position.y, 2);
        a = Math.Sqrt(a);
        if (a <= padding)
            stop = false;
        else
            stop = true;

        if (stop)
        {
            moveUpdate();
        }

        //            moveUpdate();
    }

    void moveUpdate()
    {
        pos = transform.position;
        dir = parent.transform.position - pos;
        dir.Normalize();
        gameObject.transform.Translate(dir * moveSpeed * Time.deltaTime);

        //        stop = false;
    }

    private void SpeedUpEvent()
    {
        moveSpeed *= speedUp;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
            deadEvent.Dead();
        if (collision.tag == "Enemy")
        {
            GameManager.instance.ChangeBooHp(-1);
            ObjectPoolManager.instance.ReturnEnemy(collision.GetComponent<Enemy>());
        }
    }
}
