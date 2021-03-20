using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    public float createBombTime = 1f;

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
            yield return new WaitForSeconds(createBombTime);

            Bomb newBomb = ObjectPoolManager.instance.GetBomb();
            newBomb.transform.position = GetInsidePosition();
            newBomb.gameObject.SetActive(true);
            newBomb.StartBombCoroutine();
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
