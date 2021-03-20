using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    public GameObject foodPrefab;
    private Stack<GameObject> _stack_Food;

    public GameObject tailPrefab;
    private Stack<GameObject> _stack_Tail;

    protected override void OnAwake()
    {
        base.OnAwake();

        _stack_Food = new Stack<GameObject>();
        _stack_Tail = new Stack<GameObject>();
    }

    #region FOOD
    public GameObject GetFood()
    {
        int len = _stack_Food.Count;

        if (len == 0)
            MakeFood(1);

        return _stack_Food.Pop(); ;
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
        }
    }
    #endregion

    #region TAIL
    public GameObject GetTail()
    {
        int len = _stack_Tail.Count;

        if (len == 0)
            MakeTail(1);

        return _stack_Tail.Pop(); ;
    }

    public void ReturnTail(GameObject tail)
    {
        _stack_Tail.Push(tail);

        if (tail.activeSelf)
            tail.SetActive(false);
    }

    private void MakeTail(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject tail = Instantiate(tailPrefab);
            _stack_Tail.Push(tail);
            tail.SetActive(false);
        }
    }
    #endregion
}
