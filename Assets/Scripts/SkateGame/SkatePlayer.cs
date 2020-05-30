using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkatePlayer : MonoBehaviour
{
    public Vector2 jumpForce = new Vector2(0, 200);
    public bool isGrounded = false;
    Rigidbody2D jumpBody;

    // Start is called before the first frame update
    void Start()
    {
        jumpBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            jumpBody.AddForce(jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}