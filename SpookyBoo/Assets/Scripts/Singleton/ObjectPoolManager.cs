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

    [Header("Enemy")]
    public Enemy enemyPrefab;
    private Stack<Enemy> _stack_Enemy;

    [SerializeField]
    private Transform enemyParent;

    [Header("Bomb")]
    public Bomb bombPrefab;
    private Stack<Bomb> _stack_Bomb;

    [SerializeField]
    private Transform bombParent;

    protected override void OnAwake()
    {
        base.OnAwake();

        _stack_Food = new Stack<GameObject>();
        _stack_Tail = new Stack<tail>();
        _stack_Enemy = new Stack<Enemy>();
        _stack_Bomb = new Stack<Bomb>();
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
            tail.transform.SetParent(tailParent);
        }
    }
    #endregion

    #region Enemy
    public Enemy GetEnemy()
    {
        int len = _stack_Enemy.Count;

        if (len == 0)
            MakeEnemy(1);

        return _stack_Enemy.Pop(); ;
    }

    public void ReturnTail(Enemy enemy)
    {
        _stack_Enemy.Push(enemy);

        if (enemy.gameObject.activeSelf)
            enemy.gameObject.SetActive(false);
    }

    private void MakeEnemy(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab);
            _stack_Enemy.Push(enemy);
            enemy.gameObject.SetActive(true);
            enemy.transform.SetParent(enemyParent);
        }
    }
    #endregion

    #region Bomb
    public Bomb GetBomb()
    {
        int len = _stack_Bomb.Count;

        if (len == 0)
            MakeBomb(1);

        return _stack_Bomb.Pop(); ;
    }

    public void ReturnBomb(Bomb bomb)
    {
        _stack_Bomb.Push(bomb);

        if (bomb.gameObject.activeSelf)
            bomb.gameObject.SetActive(false);
    }

    private void MakeBomb(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Bomb bomb = Instantiate(bombPrefab);
            _stack_Bomb.Push(bomb);
            bomb.gameObject.SetActive(true);
            bomb.transform.SetParent(bombParent);
        }
    }
    #endregion
}
