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

    [SerializeField]
    private int bigbooLv = 1;
    [SerializeField]
    private int booLv = 0;
    [SerializeField]
    private int tempBigBooLv = 1;

    private int curHp;
    private float hungryPoint = 100;
    public float hungry = 1f;

    private void Start()
    {
        deadEvent = new DeadEvent();
        curHp = MaxHP;
    }

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        BooLevelUp();
    //    }
    //}

    public void BooLevelUp()
    {
        booLv++;

        if (booLv % 4 == 0)
        {
            tempBigBooLv++;

            if (tempBigBooLv == 2)
            {
                cb.gameObject.SetActive(true);
            }

            if (tempBigBooLv == 3)
            {
                wave.gameObject.SetActive(true);
                wave.StartWaveCoroutine();
            }
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
        ChangeBigBooHungry(Time.deltaTime * -hungry);
    }
    public void ChangeBigBooHungry(float value)
    {
        hungryPoint += value;

        if (hungryPoint >= 100)
            hungryPoint = 100;
        else if (hungryPoint <= 0)
            PC.GetComponent<moveCharacter>().onDead();
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
