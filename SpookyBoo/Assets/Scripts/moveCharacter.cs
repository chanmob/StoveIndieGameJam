using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moveCharacter : MonoBehaviour
{
    public GameObject BigBoo;
    public float moveSpeed = 0.5f, speedUp;
    public int n_needTail = 3;
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
            if (GameManager.instance.getBooLv() < 4)
            {
                gameObject.GetComponent<Transform>().localScale = gameObject.GetComponent<Transform>().localScale + new Vector3(0.05f, 0.05f, 0);
                //                Boo 크기 조정
                GameManager.instance.setBooLv(1);
                for (int i = 0; i < 5; i++)
                    transform.GetComponent<BooTail>().DeleteTail();
            }

            if (GameManager.instance.getBigBooLv() > 2)
            {
            }
            else if (GameManager.instance.getBooLv() == 4)
            {
                GameManager.instance.setBooLv(-4);
                GameManager.instance.setBigBooLv(1);
                BigBoo.GetComponent<Transform>().localScale = BigBoo.GetComponent<Transform>().localScale + new Vector3(0.05f, 0.05f, 0);
            }

            transform.GetComponent<BooTail>().n_tail -= 5;
            if (transform.GetComponent<BooTail>().n_tail == 0)
                gameObject.GetComponent<BooTail>().first = true;
        }
        if (Input.GetKeyUp(KeyCode.W) && transform.GetComponent<BooTail>().n_tail >= n_needTail)
        {
            for (int k = 0; k < n_needTail; k++)
                transform.GetComponent<BooTail>().DeleteTail();
            transform.GetComponent<BooTail>().n_tail -= n_needTail;
            if (transform.GetComponent<BooTail>().n_tail == 0)
                gameObject.GetComponent<BooTail>().first = true;
            if (n_needTail == 3)
                n_needTail = 5;
            else if (n_needTail == 5)
                n_needTail = 8;
            else if (n_needTail == 8)
                n_needTail = 999;
            moveSpeed *= speedUp;
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
        if(collision.tag == "Enemy")
        {
            GameManager.instance.ChangeBooHp(-1);
            ObjectPoolManager.instance.ReturnEnemy(collision.GetComponent<Enemy>());
        }
    }

    void onDead()
    {
        Destroy(gameObject);
    }
}

