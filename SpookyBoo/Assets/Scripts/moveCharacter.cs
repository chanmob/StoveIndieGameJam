using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moveCharacter : MonoBehaviour
{

    public float moveSpeed = 0.5f;
    new Vector3 dir, m_scale;
    DeadEvent deadEvent;

    void Start()
    {
        deadEvent = new DeadEvent();
        deadEvent.onDead += new DeadEvent.deadHandler(onDead);
    }
    void Update()
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

    void moveUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos -= new Vector3(0, 0, mousePos.y);
        dir = mousePos - gameObject.transform.position;
        dir = dir.normalized;
        dir = new Vector3(dir.x, dir.y, 0);
        gameObject.transform.Translate(dir * moveSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BigBoo")
        {
            deadEvent.Dead();
        }
    }

    void onDead()
    {
        Destroy(this);
    }
}

