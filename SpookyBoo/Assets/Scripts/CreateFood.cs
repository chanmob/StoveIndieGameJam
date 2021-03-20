using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFood : MonoBehaviour
{
    public float createFoodTime = 3f;

    public PolygonCollider2D c;
    public Collider2D ct;
    public GameObject g;

    private int layerMask = 0;

    private void Start()
    {
        //layerMask = 1 << LayerMask.NameToLayer("BigBooInside");

        //for (int i = 0; i < 100; i++)
        //{
        //    Vector2 pos = new Vector2(Random.Range(c.bounds.min.x, c.bounds.max.x), Random.Range(c.bounds.min.y, c.bounds.max.y));
        //    Ray2D ray = new Ray2D(pos, Vector2.zero);
        //    RaycastHit2D hit;
        //    hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layerMask);
        //    if (hit)
        //    {
        //        Debug.Log("AAAA");
        //        GameObject newg = Instantiate(g);
        //        newg.transform.position = pos;
        //    }
        //}
    }

    private IEnumerator CreateFoodCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(createFoodTime);

            Vector2 randomPosition = Random.insideUnitSphere;// * GameManager.instance.radius;
            randomPosition = new Vector2(randomPosition.x, Mathf.Abs(randomPosition.y));

            GameObject newFood = ObjectPoolManager.instance.GetFood();
            newFood.transform.position = randomPosition;
            newFood.SetActive(true);
        }
    }
}
