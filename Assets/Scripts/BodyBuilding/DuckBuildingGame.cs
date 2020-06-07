using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DuckBuildingGame : MonoBehaviour
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
    // Update is called once per frame
    void Update()
    {
        if((lifts % 2) == 0)
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
			FindObjectOfType<GameManager>().Won();
		}
		
		if(timer <= 0)
		{
			FindObjectOfType<GameManager>().Lost();
		}
		else
		{
			timer -= Time.deltaTime;
		}
    }

}
