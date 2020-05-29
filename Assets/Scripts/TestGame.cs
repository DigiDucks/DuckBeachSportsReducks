using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGame : GameTemplate
{
    [SerializeField] string instructions = "Do a thing to win the game";

    public override void Begin()
    {
       //For the GameManager to call when you want the game to start
    }

    public override void Lose()
    {
        //What happens when you lose the game, also tell the GameManager when lost
    }

    public override void Win()
    { 
        //What happens when you win the game, tell the GameManager here
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
