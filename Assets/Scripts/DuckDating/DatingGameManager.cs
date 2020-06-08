using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net.Http.Headers;

public class DatingGameManager : GameTemplate
{
    [SerializeField]
    float timer = 20f;

    bool start = false;

    [SerializeField]
    Text timerText;

    [SerializeField]
    GameObject playerBlush;

    [SerializeField]
    GameObject tear;

    [SerializeField]
    Animator dateAnim;
    public override void Begin()
    {
        start = true;
        timerText.gameObject.SetActive(true);
    }

    public override void Lose()
    {
        start = false;
        timerText.text = "They Got Away :'(";
        StartCoroutine("LoseBuffer");
    }

    public override void Win()
    {
        start = false;
        timerText.text = "Date Get!";
        StartCoroutine("WinBuffer");

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

    IEnumerator LoseBuffer()
    {
        dateAnim.Play("WalkOUt");
        tear.SetActive(true);
        yield return new WaitForSeconds(2f);
        GameManager.instance.Lost();
    }
}
