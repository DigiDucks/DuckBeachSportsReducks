using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class BallMovement : MonoBehaviour
{

	[Tooltip("Position we want to hit")]
	public Vector3 targetPos;

	[Tooltip("Horizontal speed, in units/sec")]
	public float speed = 10;

	[Tooltip("How high the arc should be, in units")]
	public float arcHeight = 1;


	Vector3 startPos, initialPos;

	public bool returned = false;
	public bool started = false;


	GameTemplate game;
	VBEnemy enemy;

	Collider2D coll;
	public SpriteRenderer rend;
	// Start is called before the first frame update
	void Start()
	{
		// Cache our start position, which is really the only thing we need
		// (in addition to our current position, and the target).
		startPos = transform.position;
		initialPos = startPos;
		game = FindObjectOfType<VolleyBall>();
		coll = GetComponent<Collider2D>();
		rend = GetComponent<SpriteRenderer>();
		enemy = FindObjectOfType<VBEnemy>();
	}

	// Update is called once per frame
	void Update()
	{
		if (started)
		{
			// Compute the next position, with arc added in
			float x0 = startPos.x;
			float x1 = targetPos.x;
			float dist = x1 - x0;
			float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
			float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
			float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
			Vector3 nextPos = new Vector3(nextX, baseY + arc, transform.position.z);

			// Rotate to face the next position, and then move there
			//transform.rotation = LookAt2D(nextPos - transform.position);
			transform.position = nextPos;

			// Do something when we reach the target
			if (Mathf.Approximately( nextPos.y, targetPos.y)) Arrived();
		}
	}

	void Arrived()
	 {
		
		started = false;
		if (returned)
		{
			returned = false;
			SetNewPath(returned);
		}
		else
		{
			game.Lose();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<VBPlayer>() != null && !returned)
		{
			returned = true;
			SetNewPath(returned);
			enemy.SetMove(targetPos);
		}
	}

	private void SetNewPath(bool _returned)
	{
		if (_returned)
		{
			startPos = transform.position;
 			targetPos = new Vector3((int)Random.Range(-2, 5), -0.5f, 0); ;
		}
		else
		{
			startPos = targetPos;
			targetPos = new Vector3((int)Random.Range(-5, 0), -6, 0);
		}
		started = true;
	}
}
