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
    bool dancing = false;

    string[] dances = new string[3] { "TheBounce", "SideToSide", "TheLean" };

    [SerializeField]
    Text timerText;

    [SerializeField]
    GameObject playerBlush;

    [SerializeField]
    GameObject tear;

    [SerializeField]
    Animator dateAnim;
    public Animator playerAnim;

    [SerializeField]
    SpriteRenderer background;
    public Sprite danceBackground;
    public AudioSource musicPlayer;
    public AudioClip danceMusic;

    private void Start()
    {
        switch (GameManager.instance.level)
        {
            case 1: timer = 15f;
                break;
            case 2: timer = 11f;
                    int random = UnityEngine.Random.Range(1, 4);
                     if (random >=3) DanceTime();
                break;
            case 3: timer = 7f;
                    DanceTime();
                break;
        }
    }

    void DanceTime()
    {
        background.sprite = danceBackground;
        musicPlayer.clip = danceMusic;
        musicPlayer.Play();
        dancing = true;
       }

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
        if (dancing)
        {
            playerAnim.Play(dances[UnityEngine.Random.Range(0, dances.Length)]);
            dateAnim.Play(dances[UnityEngine.Random.Range(0, dances.Length)]);
        }
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
