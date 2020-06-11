using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rb;
	[SerializeField] private float speed;
	[SerializeField] private float moveInput;
	[SerializeField] private float jumpForce;
	[SerializeField] private float fallForce;
	private bool onGround;

	[SerializeField] private GameObject[] duckHeads;
	[SerializeField] private int duckHP = 5;

	AudioSource flapSound;



	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		flapSound = GetComponent<AudioSource>();

        switch (GameManager.instance.level)
        {
			case 1: duckHP = 5;
				break;
			case 2: duckHP = 4;
				break;
			case 3: duckHP = 3;
				break;
        }
    }

    // Update is called once per frame
    void Update()
    {
		DuckHeadThings();
		if(duckHP == 0)
		{
			Lost();
		}
    }

	void DuckHeadThings()
	{
		int i = 0;
		foreach (GameObject go in duckHeads)
		{
			if(i != duckHP)
			{
				go.SetActive(true);
				i++;
			}
			else
			{
				go.SetActive(false);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("SeagullBlast"))
		{
			duckHP--;
			Destroy(collision.gameObject);
		}
	}

	private void FixedUpdate()
	{
		moveInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveInput * speed * Time.deltaTime, 0f);

		if(Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector2.up * jumpForce);
			flapSound.PlayOneShot(flapSound.clip);
		}

		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			rb.velocity = Vector2.up * fallForce;
		}
	}

	void Lost()
	{
		FindObjectOfType<GameManager>().Lost();
	}

	
}
