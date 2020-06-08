using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KayakDuckPlayerCode : MonoBehaviour
{

	private Transform myTransform;
	public Transform[] pos;
	public int posInt = 1;
	[SerializeField] private KeyCode Left;
	[SerializeField] private KeyCode Right;

	[SerializeField] private KeyCode LeftII;
	[SerializeField] private KeyCode RightII;

	public Sprite hitSprite;
	public Sprite standardSprite;

	private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
		GetComponent<SpriteRenderer>().sprite = standardSprite;
    }

    // Update is called once per frame
    void Update()
    {
		if(isAlive)
		{
			MovementInputs();
		}
		else
		{
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("Obs"))
			{
				go.GetComponent<Rigidbody2D>().gravityScale = 0;
				go.GetComponent<Rigidbody2D>().angularDrag = 0;
				go.GetComponent<Rigidbody2D>().mass = 0;
			}
		}
		gameObject.transform.position = pos[posInt].position;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		GetComponent<SpriteRenderer>().sprite = hitSprite;
		isAlive = false;
		Destroy(collision.gameObject);
		StartCoroutine("LoseBuffer");
		
	}

	void MovementInputs()
	{
		if(Input.GetKeyDown(Left) || Input.GetKeyDown(LeftII))
		{
			posInt--;
		}

		if (Input.GetKeyDown(Right) || Input.GetKeyDown(RightII))
		{
			posInt++;
		}

		if(posInt > 2)
		{
			posInt = 2;
		}
		else if(posInt < 0)
		{
			posInt = 0;
		}
	}

	IEnumerator LoseBuffer()
    {
		yield return new WaitForSeconds(1f);
		GameManager.instance.Lost();
	}
}
