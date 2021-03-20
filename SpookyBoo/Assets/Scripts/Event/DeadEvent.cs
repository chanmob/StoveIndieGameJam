using UnityEngine;
using System;

public class DeadEvent
{
    public delegate void deadHandler();
    public event deadHandler onDead;
    public void Dead()
    {
        onDead();
    }
}
