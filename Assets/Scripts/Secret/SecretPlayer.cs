using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SecretPlayer : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;

    [SerializeField]
     float maxVelocity = 100f;

    [SerializeField]
    AudioClip win;

    [SerializeField]
    Text timerText;

    public Rigidbody2D body;
    public bool moving = true;

    float timer = 30f;
    bool startTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startTimer = true;
        GameManager.instance.StartCoroutine(GameManager.instance.StartSequence());
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                timerText.text = Convert.ToInt32(timer).ToString();
            }
            else
            {
                GameManager.instance.GetComponent<AudioSource>().PlayOneShot(win);
                GameManager.instance.lives = 99;
                SceneManager.LoadScene(0);
            }
        }
        if (moving)
        {
            body.AddForce(Vector2.right * speed * Time.deltaTime);
            if (Input.GetAxis("Vertical") != 0)
            {
                body.AddForce(Vector2.up * Input.GetAxis("Vertical") * speed * 5 * Time.deltaTime);
            }
            body.velocity = new Vector2(Mathf.Clamp(body.velocity.x, 0, maxVelocity), Mathf.Clamp(body.velocity.y, -maxVelocity, maxVelocity));
        }
    }
}
