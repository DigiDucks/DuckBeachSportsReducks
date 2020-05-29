using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    GameManager manager;
public void FinishedGame(bool won)
    {
        manager = GameManager.instance;
        if (won)
        {
            manager.Won();
        }
        else
        {
            manager.Lost();
        }
    }
}
