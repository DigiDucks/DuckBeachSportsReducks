using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfingManager : GameTemplate
{
    [SerializeField]
    Sprite[] sprites;
    
    string[] moves = new string[5] { "q", "w", "a", "s", "d" };

    string currentMove= "null";
    string inputMove = "null";

    int correctMove = 0;
    int goal = 5;

    bool stunt = false;

    SpriteRenderer rend;

    [SerializeField]
    Animator duckAnim;

    [SerializeField]
    AudioSource successSound;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        switch (GameManager.instance.level)
        {
            case 1: goal = 5;
                break;
            case 2: goal = 6;
                break;
            case 3: goal = 7;
                break;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        ReadInput();


    }


    void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inputMove = "q";
            stunt = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            inputMove = "w";
            stunt = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            inputMove = "a";
            stunt = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            inputMove = "s";
            stunt = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            inputMove = "d";
            stunt = true;
        }

        if (stunt)
        {
            if (inputMove == currentMove)
            {
                correctMove++;
                if (correctMove < goal)
                {
                    successSound.PlayOneShot(successSound.clip);
                    duckAnim.Play(inputMove);
                   StartCoroutine(Trick());
                    stunt = false;
                }
                else
                {
                    Win();
                }
            }
            else
            {
                Lose();
            }
        }
    }



    public override void Begin()
    {
        StartCoroutine(Trick());
    }

    public override void Lose()
    {

        Debug.Log("Lose");
        GameManager.instance.Lost();
    }

    public override void Win()
    {
        Debug.Log("Win");
        StartCoroutine(WinBuffer());
    }

    IEnumerator Trick()
    {
        rend.enabled = false;
        yield return new WaitForSeconds(0.25f);
        int i = Random.Range(0, moves.Length);

        rend.sprite = sprites[i];
        rend.enabled = true;

        currentMove = moves[i];

        //Debug.Log(currentMove);
    }

    IEnumerator WinBuffer()
    {
        FindObjectOfType<SurfTimer>().canCall = false;
        duckAnim.Play("DuckDab");
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.Won();
    }



}
