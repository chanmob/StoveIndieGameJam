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

    private void Start()
    {
        deadEvent = new DeadEvent();
        curHp = MaxHP;
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
}
