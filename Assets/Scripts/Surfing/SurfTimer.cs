using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfTimer : MonoBehaviour
{
   public bool canCall = true;

    public void Call()
    {
        Debug.Log("Bummber");
        if (canCall)
        {
            FindObjectOfType<SurfingManager>().Lose();
        }
    }
}
