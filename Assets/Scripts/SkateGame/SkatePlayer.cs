using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkatePlayer : MonoBehaviour
{
    public Vector2 jumpForceStanding = new Vector2(0, 200);
    public Vector2 jumpForceCrouching = new Vector2(0, 100);
    public Vector3 crouch = new Vector3(1.5f, 0.5f, 1);
    public bool isGrounded = false;
    private bool isCrouched = false;
    private Vector3 unCrouchScale = new Vector3(1.5f, 1.5f, 1);
    Rigidbody2D jumpBody;
    GameManager manager;

    public float speedMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {

        switch (GameManager.instance.level)
        {
            case 1: speedMultiplier = 1f;
                break;
            case 2: speedMultiplier = 1.3f;
                break;
            case 3: speedMultiplier = 1.65f;
                break;
        }
        jumpBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Crouch
        if (Input.GetKey(KeyCode.S))
        {
            if (isCrouched == false)
            {
                isCrouched = true;
                transform.localScale = crouch;
                transform.Translate(0, -0.885f, 0);
                jumpBody.gravityScale += 0.5f;
            }
        }
        else
        {
            if (isCrouched == true)
            {
                isCrouched = false;
                transform.localScale = unCrouchScale;
                transform.Translate(0, 0.885f, 0);
                jumpBody.gravityScale -= 0.5f;
            }
        }
        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            if (isCrouched)
            {
                jumpBody.AddForce(jumpForceCrouching);
            }
            else
            {
                jumpBody.AddForce(jumpForceStanding);
            }
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Give a jump when ground is hit
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        //let me speak to the manager
        if(collision.gameObject.CompareTag("Death"))
        {
            manager = GameManager.instance;
            manager.Lost();        
        }
        //Win
        if (collision.gameObject.CompareTag("Win"))
        {
            manager = GameManager.instance;
            manager.Won();
        }
    }
}