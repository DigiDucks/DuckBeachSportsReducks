using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class VolleyBall : GameTemplate
{
    BallMovement ball, secondBall,thirdBall;
    int count = 0;
    float speedMultiplier = 1f;
    [SerializeField]
    int goal = 6;

    bool third = false;

    public Text scoreText;
    public Text goalText;

    [SerializeField]
    GameObject enemyTear;
    [SerializeField]
    GameObject playerTear;

    [SerializeField]
    GameObject otherBall;

  

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

        switch (GameManager.instance.level)
        {
            case 1:speedMultiplier = 1f;
                break;
            case 2:speedMultiplier = 0.85f;
                StartCoroutine(AnotherBall());
                break;
            case 3:speedMultiplier = .8f;
                third = true;
                StartCoroutine(AnotherBall());
                break;
        }
        ball.speed *= speedMultiplier;
    }

    public override void Lose()
    {
        StartCoroutine("LoseSequence");
    }

    public override void Win()
    {
        StartCoroutine("WinSequence");
    }

    public void VolleyCount()
    {
        count++;
        scoreText.text = "Volley \n" + count.ToString();
        if (count >= goal)
        {
            ball.won = true;
            if(secondBall!=null) secondBall.gameObject.SetActive(false);
            if (thirdBall != null) thirdBall.gameObject.SetActive(false);
        }

    }

    IEnumerator Serve()
    {
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<VBEnemy>().anim.Play("GullBump");
        ball.started = true;
    }

    IEnumerator LoseSequence()
    {
        ball.started = false;
        GameObject player = FindObjectOfType<VBPlayer>().gameObject;
        playerTear.SetActive(true);
        player.transform.Rotate(new Vector3(0, 0, 90f));
        yield return new WaitForSeconds(1.25f);
        GameManager.instance.Lost();

    }

    IEnumerator WinSequence()
    {
        ball.started = false;
        ball.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 2);
        enemyTear.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.Won();
    }

    IEnumerator AnotherBall()
    {
        Debug.Log("Called");
        yield return new WaitForSeconds(2f);
        if (secondBall == null)
        {
            secondBall = Instantiate(otherBall, FindObjectOfType<VBEnemy>().transform.position, transform.rotation).GetComponent<BallMovement>();
            secondBall.speed *= speedMultiplier;
        }
        if (third) 
        {
            yield return new WaitForSeconds(2f);
            thirdBall = Instantiate(otherBall, FindObjectOfType<VBEnemy>().transform.position, transform.rotation).GetComponent<BallMovement>();
            thirdBall.speed *= speedMultiplier;
        }

    }
}
