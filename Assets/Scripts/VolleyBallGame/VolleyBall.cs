using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class VolleyBall : GameTemplate
{
    BallMovement ball;
    int count = 0;
    [SerializeField]
    int goal = 6;

    public Text scoreText;
    public Text goalText;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<BallMovement>();
    }

    public override void Begin()
    {
        StartCoroutine("Serve");
        scoreText.text = "Volley \n" + count.ToString();
        goalText.text = "Goal \n" + goal.ToString();
    }

    public override void Lose()
    {
        StartCoroutine("LoseSequence");
    }

    public override void Win()
    {
        GameManager.instance.Won();
    }

    public void VolleyCount()
    {
        count++;
        scoreText.text = "Volley \n" + count.ToString();
        if (count >= goal) Win();

    }

    IEnumerator Serve()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<VBEnemy>().anim.Play("GullBump");
        ball.started = true;
    }

    IEnumerator LoseSequence()
    {
        GameObject player = FindObjectOfType<VBPlayer>().gameObject;
        player.transform.Rotate(new Vector3(0, 0, 90f));
        yield return new WaitForSeconds(1.25f);
        GameManager.instance.Lost();

    }
}
