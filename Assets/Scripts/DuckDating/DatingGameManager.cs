using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DatingGameManager : GameTemplate
{
    float timer = 20f;

    bool start = false;

    [SerializeField]
    Text timerText;

    [SerializeField]
    GameObject playerBlush;
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
        start = false;
        timerText.text = "Date Get!";
        StartCoroutine("WinBuffer");

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
                timerText.text = Convert.ToInt32(timer).ToString();
            }
            else
            {
                Lose();
            }
        }
    }

    IEnumerator WinBuffer()
    {
        playerBlush.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.Won();
    }
}
