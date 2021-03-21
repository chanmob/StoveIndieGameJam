using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tail : MonoBehaviour
{
    public float moveSpeed = 3.0f, speedUp = 1.2f;
    public Vector3 pos, dir, des;
    public bool arrive = false, stop = true;
    public float padding;
    public GameObject parent, child;

    SpeedEvent speed;
    void Start()
    {
        speed = new SpeedEvent();
        speed.onSpeed += new SpeedEvent.speedHandler(SpeedUpEvent);
    }


    private void FixedUpdate()
    {
        if(parent != null)
            if (parent.tag == "Player")
                padding = 0.8f;
        double a = Math.Pow(parent.transform.position.x - transform.position.x, 2) + Math.Pow(parent.transform.position.y - transform.position.y, 2);
        a = Math.Sqrt(a);
        if (a <= padding)
            stop = false;   
        else
            stop = true;

        if (stop) {
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
        if (collision.tag == "BigBoo")
        {
            onDead();
        }

        if (collision.tag == "Bomb")
            deadEvent.Dead();

        if (collision.CompareTag("Food"))
        {
            _anim.SetTrigger("Eat");

            ObjectPoolManager.instance.ReturnFood(collision.gameObject);
            gameObject.GetComponent<BooTail>().CreateTail(dir);
            switch (foodCreater.transform.GetComponent<CreateFood>().randomIndex)
            {
                case 0:
                    GameManager.instance.ChangeBigBooHungry(10);
                    break;
                case 1:
                    GameManager.instance.ChangeBigBooHungry(15);
                    break;
                case 2:
                    GameManager.instance.ChangeBigBooHungry(20);
                    break;
                case 3:
                    GameManager.instance.ChangeBigBooHungry(25);
                    break;
                case 4:
                    GameManager.instance.ChangeBigBooHungry(30);
                    break;

            }

        }




    }
