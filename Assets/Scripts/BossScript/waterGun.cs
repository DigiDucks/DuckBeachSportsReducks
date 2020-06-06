using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterGun : MonoBehaviour
{
	public Transform gunPoint;
	public GameObject bullet;

	[SerializeField] private float startTimer;
	private float timer;
    
    // Update is called once per frame
    void Update()
    {
		if(Input.GetMouseButton(0))
		{
			if (timer <= 0)
			{
				Instantiate(bullet, gunPoint);
				timer = startTimer;
			}
		}

		timer -= Time.deltaTime;

    }

	void SetTime()
	{

	}
}
