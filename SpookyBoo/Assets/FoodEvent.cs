using UnityEngine;
using System;

public class FoodEvent
{
    public delegate void foodHandler(int foodType);
    public event foodHandler onEat;
    public void eatFood(int foodType)
    {
        onEat(foodType);
    }
}
