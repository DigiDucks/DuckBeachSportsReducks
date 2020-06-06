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

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        
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
                    Trick();
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

    void Trick()
    {
        int i = Random.Range(0, moves.Length);

        rend.sprite = sprites[i];

        currentMove = moves[i];

        //Debug.Log(currentMove);
    }

    public override void Begin()
    {
        Trick();
    }

    public override void Lose()
    {

        Debug.Log("Lose");
        GameManager.instance.Lost();
    }

    public override void Win()
    {
        Debug.Log("Win");
        GameManager.instance.Won();
    }





}
