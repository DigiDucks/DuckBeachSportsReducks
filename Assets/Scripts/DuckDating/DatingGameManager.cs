using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatingGameManager : GameTemplate
{
    float timer = 30f;

    bool start = false;

    public override void Begin()
    {
        start = true;
    }

    public override void Lose()
    {
        GameManager.instance.Lost();
    }

    public override void Win()
    {
        GameManager.instance.Won();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Lose();
            }
        }
    }
}
