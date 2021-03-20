using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    [Header("Food")]
    [SerializeField]
    private Sprite[] foodSprite;

    public GameObject foodPrefab;

    private Stack<GameObject> _stack_Food;

    [SerializeField]
    private Transform foodParent;

    [Header("Tail")]
    [SerializeField]
    private Sprite[] tailSprite;

    public tail tailPrefab;
    private Stack<tail> _stack_Tail;

    [SerializeField]
    private Transform tailParent;

    protected override void OnAwake()
    {
        base.OnAwake();

        _stack_Food = new Stack<GameObject>();
        _stack_Tail = new Stack<tail>();
    }

    #region FOOD
    public GameObject GetFood(int foodSpriteIdx = 0)
    {
        int len = _stack_Food.Count;

        if (len == 0)
            MakeFood(1);

        GameObject newFood = _stack_Food.Pop();
        newFood.GetComponent<SpriteRenderer>().sprite = foodSprite[foodSpriteIdx];

        return newFood;
    }

    public void ReturnFood(GameObject food)
    {
        _stack_Food.Push(food);

        if (food.activeSelf)
            food.SetActive(false);
    }

    private void MakeFood(int count)
    {
        for(int i = 0; i < count; i++)
        {
            GameObject food = Instantiate(foodPrefab);
            _stack_Food.Push(food);
            food.SetActive(false);
            food.transform.SetParent(foodParent);
        }
    }
    #endregion

    #region TAIL
    public tail GetTail(int tailSpriteIdx = 0)
    {
        int len = _stack_Tail.Count;

        if (len == 0)
            MakeTail(1);

        tail newTail = _stack_Tail.Pop();
        newTail.gameObject.GetComponent<SpriteRenderer>().sprite = tailSprite[tailSpriteIdx];

        return newTail;
    }

    public void ReturnTail(tail tail)
    {
        _stack_Tail.Push(tail);

        if (tail.gameObject.activeSelf)
            tail.gameObject.SetActive(false);
    }

    private void MakeTail(int count)
    {
        for (int i = 0; i < count; i++)
        {
            tail tail = Instantiate(tailPrefab);
            _stack_Tail.Push(tail);
            tail.gameObject.SetActive(true);
            tail.gameObject.transform.SetParent(tailParent);
        }
    }
    #endregion
}
