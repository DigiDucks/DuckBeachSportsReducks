using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolleyBall : GameTemplate
{
    BallMovement ball;


    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<BallMovement>();
    }

    public override void Begin()
    {
        StartCoroutine("Serve");
    }

    public override void Lose()
    {
        Debug.Log("Lose");
    }

    public override void Win()
    {

    }

    IEnumerator Serve()
    {
        yield return new WaitForSeconds(1f);
        ball.started = true;
    }
}
