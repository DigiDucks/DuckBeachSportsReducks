using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DuckBuildingGame : GameTemplate
{

	public int lifts = 0;
	public int reps = 0;

	public int ArraySection;

	public Sprite[] duckSprites;
	public Vector3[] duckPos;
	public Vector2[] barPos;
	public int[] buffBarriers;

	public GameObject bar;

	public float timer;

	public Text timerText;
	public Text repText;

	public int RepRequired;

	public SpriteRenderer arrow;
	[SerializeField]
	GameObject tear;

	[Tooltip("Buff Ducks For win screen")]
	[SerializeField]
	GameObject[] buffDucks;

	bool started = false;
   

    // Update is called once per frame
    void Update()
    {
        if((lifts % 2) == 0 && started)
		{
			if(Input.GetKeyDown(KeyCode.W))
			{
				lifts++;
			}
			arrow.flipY = false;
			GetComponent<SpriteRenderer>().sprite = duckSprites[ArraySection];
			bar.transform.position = barPos[ArraySection];
			transform.position = duckPos[ArraySection];
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.S))
			{
				lifts++;
			}
			arrow.flipY = true;
			GetComponent<SpriteRenderer>().sprite = duckSprites[ArraySection + 1];
			transform.position = duckPos[ArraySection];
			bar.transform.position = barPos[ArraySection + 1];
		}

		reps = lifts / 2;

		if(reps > buffBarriers[0])
		{
			if (reps > buffBarriers[1])
			{
				if (reps > buffBarriers[2])
				{
					ArraySection = 6;
				}
				else
				{
					ArraySection = 4;
				}
			}
			else
			{
				ArraySection = 2;
			}
		}
		else
		{
			ArraySection = 0;
		}

		timerText.text = Convert.ToInt32(timer).ToString();
		repText.text = "Reps: " + reps.ToString();

		if(reps >= RepRequired)
		{
			Win();
		}
		
		if(timer <= 0)
		{
			Lose();
		}
		else
		{
			timer -= Time.deltaTime;
		}
    }


	public override void Begin()
	{
		started = true;
	}

	public override void Lose()
	{
		StartCoroutine("LoseBuffer");
	}

	public override void Win()
	{
		StartCoroutine("WinBuffer");
	}

	IEnumerator WinBuffer()
    {
		started = false;
		arrow.enabled = false;
		foreach (GameObject duck in buffDucks)
		{
			duck.SetActive(true);
		}
		yield return new WaitForSeconds(2f);
		GameManager.instance.Won();
    }

	IEnumerator LoseBuffer()
    {
		started = false;
		arrow.enabled = false;
		bar.transform.position = new Vector2(-1f, -2f);
		tear.SetActive(true);
		yield return new WaitForSeconds(1.5f);
		GameManager.instance.Lost();
    }

}
