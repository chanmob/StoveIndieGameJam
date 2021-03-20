using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moveCharacter : MonoBehaviour
{
    public GameObject BigBoo;
    public float moveSpeed = 0.5f, speedUp;
    new Vector3 dir, m_scale;
    DeadEvent deadEvent;
    SpeedEvent speedEvent;    
    void Start()
    {
        deadEvent = new DeadEvent();
        deadEvent.onDead += new DeadEvent.deadHandler(onDead);
        speedEvent = new SpeedEvent();

    }

    private void Update()
    {
        moveUpdate();
        if (Input.GetKeyUp(KeyCode.T))
            gameObject.GetComponent<BooTail>().CreateTail(dir);
        if (Input.GetKeyUp(KeyCode.Q) && transform.GetComponent<BooTail>().n_tail >= 5)
        {
            if(GameManager.instance.getBooLv() < 5)
            {
                //                Boo 크기 조정
                GameManager.instance.setBooLv(1);
            }
            else if(GameManager.instance.getBigBooLv()<=4)
            {
                //bigboo 크기 조절
                GameManager.instance.setBooLv(-5);
                GameManager.instance.setBigBooLv(1);
            }

            transform.GetComponent<BooTail>().n_tail -= 5;
        }
        if (Input.GetKeyUp(KeyCode.W) && transform.GetComponent<BooTail>().n_tail >= 1)
        {
            transform.GetComponent<BooTail>().n_tail--;
            moveSpeed *= speedUp;
            transform.GetComponent<BooTail>().DeleteTail();
        }

    }
    /*
        void FixedUpdate()
        {
            moveUpdate();
            m_scale = gameObject.transform.localScale;
            if (dir.x <= 0)
            {
                gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            }
            if (dir.x >= 0)
            {
                gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 0);
            }
        }
    */
    void moveUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos -= new Vector3(0, 0, mousePos.z);
        dir = mousePos - gameObject.transform.position;
        dir = dir.normalized;
        gameObject.transform.Translate(dir * moveSpeed * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BigBoo")
        {
            deadEvent.Dead();
        }

        if (collision.CompareTag("Food"))
        {
            ObjectPoolManager.instance.ReturnFood(collision.gameObject);
            gameObject.GetComponent<BooTail>().CreateTail(dir);
        }
    }

    void onDead()
    {
        Destroy(gameObject);
    }
}

