using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    public float redzoneDealyTime = 30f;

    public float durationTime = 10f;
    public float createBombTime = 3f;


    [SerializeField]
    private PolygonCollider2D polyconCollider2D;

    private int layerMask = 0;

    private void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("BigBooInside");

        StartCoroutine(CreateFoodCoroutine());
    }

    private IEnumerator CreateFoodCoroutine()
    {
        while (true)
        {
            float time = 0f;
            float curTime = 0f;

            while(time <= durationTime)
            {
                time += Time.deltaTime;
                curTime += Time.deltaTime;
                Debug.Log(time + " / " + curTime);

                if (curTime >= createBombTime)
                {
                    Debug.Log("CReate");
                    curTime = 0f;

                    Bomb newBomb = ObjectPoolManager.instance.GetBomb();
                    newBomb.transform.position = GetInsidePosition();
                    newBomb.gameObject.SetActive(true);
                    newBomb.StartBombCoroutine();
                }

                yield return null;
            }

            yield return new WaitForSeconds(redzoneDealyTime);
        }
    }

    private Vector2 GetInsidePosition()
    {
        while (true)
        {
            Vector2 pos = new Vector2(Random.Range(polyconCollider2D.bounds.min.x, polyconCollider2D.bounds.max.x), Random.Range(polyconCollider2D.bounds.min.y, polyconCollider2D.bounds.max.y));
            Ray2D ray = new Ray2D(pos, Vector2.zero);
            RaycastHit2D hit;
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layerMask);
            if (hit)
            {
                return pos;
            }
        }
    }
}
