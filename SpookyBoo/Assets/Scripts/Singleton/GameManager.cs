using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    DeadEvent deadEvent;

    public Wave wave;
    public CreateBomb cb;
    public GameObject PC;

    private const int MaxHP = 4;

    private int bigbooLv = 0;
    private int booLv = 0;

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

        if (booLv % 4 == 0 && booLv != 0)
        {
            bigbooLv++;

            if (bigbooLv == 1)
            {
                cb.gameObject.SetActive(true);
            }

            if (bigbooLv == 2)
            {
                wave.gameObject.SetActive(true);
                wave.StartWaveCoroutine();
            }
        }
        else if(booLv % 4 != 0)
        {
            booLv = 0;
            bigbooLv++;
        }
    }

    public void ChangeBooHp(int value)
    {
        curHp += value;
        UIManager.instance.mainUI.HeartRefresh(curHp);

        if (curHp >= MaxHP)
            curHp = MaxHP;

        else if (curHp == 0)
            PC.GetComponent<moveCharacter>().onDead();
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
        if(bigbooLv<=2)
            bigbooLv += value;
    }
}
