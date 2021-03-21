using UnityEngine;
using System;
public class SpeedEvent
{
    public delegate void speedHandler();
    public event speedHandler onSpeed;
    public void spdUp()
    {
        onSpeed();
    }
}
