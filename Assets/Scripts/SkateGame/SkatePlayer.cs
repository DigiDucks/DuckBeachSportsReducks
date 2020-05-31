using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkatePlayer : MonoBehaviour
{
    public Vector2 jumpForceStanding = new Vector2(0, 200);
    public Vector2 jumpForceCrouching = new Vector2(0, 100);
    public Vector3 crouch = new Vector3(1, 0.5f, 1);
    public bool isGrounded = false;
    private bool isCrouched = false; 
    Rigidbody2D jumpBody;
    GameManager manager; 

    // Start is called before the first frame update
    void Start()
    {
        jumpBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Crouch
        if (Input.GetButton("Vertical"))
        {
            if (isCrouched == false)
            {
                isCrouched = true;
                transform.localScale = crouch;
                transform.Translate(0, -0.885f, 0);
            }
        }
        else
        {
            if (isCrouched == true)
            {
                isCrouched = false;
                transform.localScale = Vector3.one;
                transform.Translate(0, 0.885f, 0);
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
    }
}