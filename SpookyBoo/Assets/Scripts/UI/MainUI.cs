using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Sprite[] heartSprite = new Sprite[2];

    public Image[] heartImage;

    public Text tailCount;

    public Slider hungry;

    public float max = 100;

    public void HeartRefresh(int curHp)
    {
        int len = heartImage.Length;
        if (curHp >= len)
            curHp = len;

        for(int i = 0; i < len; i++)
        {
            heartImage[i].sprite = heartSprite[0];
        }

        for (int i = 0; i < curHp; i++)
        {
            heartImage[i].sprite = heartSprite[1];
        }
    }

    public void TailCountRefresh(int count)
    {
        tailCount.text = count + " / " + max;
    }

    public void HungrySliderRefresh(float cur)
    {
        hungry.value = cur / max;
    }
}
