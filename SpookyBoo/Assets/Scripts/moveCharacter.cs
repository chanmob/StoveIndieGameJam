using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moveCharacter : MonoBehaviour
{
    public GameObject BigBoo, foodCreater;
    public float moveSpeed = 0.5f, speedUp;
    public int n_needTail = 3;
    int booLV, bigBooLv;
    new Vector3 dir, m_scale;
    DeadEvent deadEvent;
    SpeedEvent speedEvent;

    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        deadEvent = new DeadEvent();
        deadEvent.onDead += new DeadEvent.deadHandler(onDead);
        speedEvent = new SpeedEvent();
        booLV = bigBooLv = 0;
    }

    private void Update()
    {
        GameManager.instance.getLoseWeight();
        moveUpdate();
        if (Input.GetKeyUp(KeyCode.T))
            gameObject.GetComponent<BooTail>().CreateTail(dir);
        if (Input.GetKeyUp(KeyCode.Q) && transform.GetComponent<BooTail>().n_tail >= 5)
        {
            GameManager.instance.BooLevelUp();
            booLV += 1;
            if (booLV < 4)
            {
                gameObject.GetComponent<Transform>().localScale = gameObject.GetComponent<Transform>().localScale + new Vector3(0.05f, 0.05f, 0);
                //                Boo 크기 조정
                for (int i = 0; i < 5; i++)
                    transform.GetComponent<BooTail>().DeleteTail();
            }

            if (bigBooLv >= 2)
            {
            }
            else if (booLV==4)
            {
                GameManager.instance.setBigBooLv(1);
                bigBooLv++;
                booLV = 0;
                BigBoo.GetComponent<Transform>().localScale = BigBoo.GetComponent<Transform>().localScale + new Vector3(0.05f, 0.05f, 0);
                for (int i = 0; i < 5; i++)
                    transform.GetComponent<BooTail>().DeleteTail();
            }

            if (bigBooLv <= 2 && booLV < 4)
            {
                transform.GetComponent<BooTail>().n_tail -= 5;
                if (transform.GetComponent<BooTail>().n_tail == 0)
                    gameObject.GetComponent<BooTail>().first = true;
            }
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
        gameObject.GetComponent<BooTail>().tTailNum.text = transform.GetComponent<BooTail>().n_tail.ToString();

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


        if (collision.tag == "Enemy")
        {
            GameManager.instance.ChangeBooHp(-1);
            ObjectPoolManager.instance.ReturnEnemy(collision.GetComponent<Enemy>());
        }
    }

    void onDead()
    {
        _anim.SetTrigger("Die");
        SoundManager.instance.PlaySFX("GameOverSE", 1f);
        gameObject.SetActive(false);
    }
}

