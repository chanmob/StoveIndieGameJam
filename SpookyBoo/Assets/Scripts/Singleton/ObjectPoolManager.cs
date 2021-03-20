﻿using System.Collections;
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

    public GameObject tailPrefab;
    private Stack<GameObject> _stack_Tail;

    [SerializeField]
    private Transform tailParent;

    protected override void OnAwake()
    {
        base.OnAwake();

        _stack_Food = new Stack<GameObject>();
        _stack_Tail = new Stack<GameObject>();
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
    public GameObject GetTail(int tailSpriteIdx = 0)
    {
        int len = _stack_Tail.Count;

        if (len == 0)
            MakeTail(1);

        GameObject newTail = _stack_Tail.Pop();
        newTail.GetComponent<SpriteRenderer>().sprite = tailSprite[tailSpriteIdx];

        return newTail;
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
            tail.SetActive(true);
            tail.transform.SetParent(tailParent);
        }
    }
    #endregion
}
