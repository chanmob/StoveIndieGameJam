using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    DeadEvent deadEvent;

    public Wave wave;
    public CreateBomb cb;

    private const int MaxHP = 4;

    private int bigbooLv = 1;
    private int booLv = 1;

    private int curHp;
    private float hungryPoint = 100;

    private void Start()
    {
        deadEvent = new DeadEvent();
        curHp = MaxHP;
    }

    public void BooLevelUp()
    {
        booLv++;

        if (booLv % 5 == 0)
        {
            bigbooLv++;

            if(bigbooLv == 2)
            {
                cb.gameObject.SetActive(true);
            }

            if (bigbooLv == 3)
            {
                wave.gameObject.SetActive(true);
                wave.StartWaveCoroutine();
            }
        }
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

    public void getLoseWeight()
    {
        ChangeBigBooHungry(-0.1f);
    }
    public void ChangeBigBooHungry(float value)
    {
        hungryPoint += value;

        if (hungryPoint >= 100)
            hungryPoint = 100;
        else if (hungryPoint < 0)
            deadEvent.Dead();
        UIManager.instance.mainUI.HungrySliderRefresh(hungryPoint);

    }
    public int getBooLv() {
        return booLv;
    }

    public void setBooLv(int value)
    {
        booLv += value;
    }
    public int getBigBooLv()
    {
        return bigbooLv;
    }
    public void setBigBooLv(int value)
    {
        if(bigbooLv<=5)
            bigbooLv += value;
    }
}
