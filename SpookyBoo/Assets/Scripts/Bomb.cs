using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;

    private Animator _anim;

    public float scaleTime;

    private void Start()
    {
        _anim = GetComponent<Animator>();

        StartCoroutine(BombCoroutine());
    }

    private IEnumerator BombCoroutine()
    {
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime / scaleTime;
            bomb.transform.localScale = new Vector2(time, time);

            yield return null;
        }

        bomb.SetActive(false);
        _anim.SetTrigger("Bomb");
    }

    public void BombAnimationFinish()
    {
        gameObject.SetActive(false);
    }
}
