using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleImage : MonoBehaviour
{
    public OutGameMainUI outgameMainUI;

    public void TitleAnimationFinish()
    {
        outgameMainUI.CloudBtnOn();
    }
}
