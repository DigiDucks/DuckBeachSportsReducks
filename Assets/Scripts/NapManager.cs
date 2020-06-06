using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapManager : GameTemplate
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StopAllCoroutines();
            Lose();
        }
    }

    public override void Begin()
    {
        StartCoroutine("Nap");
    }

    public override void Lose()
    {
        GameManager.instance.Lost();
    }

    public override void Win()
    {
        GameManager.instance.Won();
    }

    IEnumerator Nap()
    {
        yield return new WaitForSeconds(10f);
        Win();
    }

}
