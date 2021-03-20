using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    DeadEvent deadEvent;

    private const int MaxHP = 4;

    private int bigbooLv = 1;
    private int booLv = 1;

    private int curHp;
    private int hungryPoint = 100;

    private void Start()
    {
        deadEvent = new DeadEvent();
        curHp = MaxHP;
        InvokeRepeating("getLoseWeight", 1, 5);
    }

    private void Update()
    {
        Debug.Log(hungryPoint);
    }

    public void BooLevelUp()
    {
        booLv++;

        if (booLv % 5 == 0)
            bigbooLv++;
    }

    public void ChangeBooHp(int value)
    {
        curHp += value;

        if (curHp >= MaxHP)
            curHp = MaxHP;

        else if (curHp < 0)
            deadEvent.Dead();
        UIManager.instance.mainUI.HeartRefresh(curHp);
    }

    private void getLoseWeight()
    {
        ChangeBigBooHungry(-5);
    }
    public void ChangeBigBooHungry(int value)
    {
        hungryPoint += value;

        if (hungryPoint >= 100)
            hungryPoint = 100;
        else if (hungryPoint < 0)
            deadEvent.Dead();
        UIManager.instance.mainUI.HungrySliderRefresh(hungryPoint);

    }

}
