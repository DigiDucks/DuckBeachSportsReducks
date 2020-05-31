using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KayakTimer : MonoBehaviour
{

	public float timer;
	public float startTime;

	public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
		timer = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
		{
			FindObjectOfType<GameManager>().Won();
		}
		else
		{
			timer -= Time.deltaTime;
		}

		timerText.text = Convert.ToInt32(timer).ToString();
    }
}
