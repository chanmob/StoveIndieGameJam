using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    [Header("Food")]
    public GameObject foodPrefab;
    private Stack<GameObject> _stack_Food;

    [SerializeField]
    private Transform foodParent;

    [Header("Food")]
    public GameObject tail1Prefab;
    public GameObject tail2Prefab;
    private Stack<GameObject> _stack_Tail1;
    private Stack<GameObject> _stack_Tail2;

    [SerializeField]
    private Transform tailParent;

    protected override void OnAwake()
    {
        base.OnAwake();

        _stack_Food = new Stack<GameObject>();
        _stack_Tail1 = new Stack<GameObject>();
        _stack_Tail2 = new Stack<GameObject>();
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
            food.transform.SetParent(foodParent);
        }
    }
    #endregion

    #region TAIL
    public GameObject GetTail(bool roundTail = true)
    {
        GameObject newTail = null;
        int len = 0;

        if (roundTail)
        {
            len = _stack_Tail1.Count;

            if (len == 0)
                MakeTail(1);

            newTail = _stack_Tail1.Pop();
        }
        else
        {
            len = _stack_Tail2.Count;

            if (len == 0)
                MakeTail(1);

            newTail = _stack_Tail2.Pop();
        }

        return newTail;
    }

    public void ReturnTail(GameObject tail, bool roundTail = true)
    {
        if (roundTail)
        {
            _stack_Tail1.Push(tail);
        }
        else
        {
            _stack_Tail2.Push(tail);
        }

        if (tail.activeSelf)
            tail.SetActive(false);
    }

    private void MakeTail(int count, bool roundTail = true)
    {
        if (roundTail)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject tail = Instantiate(tail1Prefab);
                _stack_Tail1.Push(tail);
                tail.SetActive(false);
                tail.transform.SetParent(tailParent);
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                GameObject tail = Instantiate(tail2Prefab);
                _stack_Tail2.Push(tail);
                tail.SetActive(false);
                tail.transform.SetParent(tailParent);
            }
        }
    }
    #endregion
}
