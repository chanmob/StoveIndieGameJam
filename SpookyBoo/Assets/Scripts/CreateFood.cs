using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFood : MonoBehaviour
{
    public float createFoodTime = 3f;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
            Debug.Log(Random.insideUnitCircle);
    }

    private IEnumerator CreateFoodCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(createFoodTime);
        }
    }
}
