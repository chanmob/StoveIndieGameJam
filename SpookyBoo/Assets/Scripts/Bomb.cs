using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;

    private CircleCollider2D circleCollider2D;

    private Animator _anim;

    public float scaleTime;

    private IEnumerator bombCoroutine;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        circleCollider2D = GetComponent<CircleCollider2D>();

        StartCoroutine(BombCoroutine());
    }

    public void StartBombCoroutine()
    {
        if(bombCoroutine != null)
        {
            StopCoroutine(bombCoroutine);
            bombCoroutine = null;
        }

        bombCoroutine = BombCoroutine();
        StartCoroutine(bombCoroutine);
    }

    private IEnumerator BombCoroutine()
    {
        bomb.SetActive(true);
        bomb.transform.localScale = Vector2.zero;
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime / scaleTime;
            bomb.transform.localScale = new Vector2(time, time);

            yield return null;
        }

        bomb.SetActive(false);
        circleCollider2D.enabled = true;
        _anim.SetTrigger("Bomb");
    }

    public void BombAnimationFinish()
    {
        bombCoroutine = null;
        circleCollider2D.enabled = false;
        ObjectPoolManager.instance.ReturnBomb(this);
    }
}
