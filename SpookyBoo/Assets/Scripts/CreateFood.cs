using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFood : MonoBehaviour
{
    public float createFoodTime = 3f;

    private void Start()
    {

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
