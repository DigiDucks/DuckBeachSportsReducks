using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void Click()
    {
        GameManager.instance.BeginTransission();
    }

    public void SpeedRun()
    {
        GameManager.instance.ToggleSpeedRun();
    }
}
