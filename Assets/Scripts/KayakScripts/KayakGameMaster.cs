using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KayakGameMaster : MonoBehaviour
{

	public GameObject obs;

	public Transform[] spwanPoints;

	public float SwapnTimer;
	public float StartSwapnTime;
	public float speedMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.instance.level)
        {
			case 1:speedMultiplier = 1f;
				break;
			case 2:speedMultiplier = 1.2f;
				break;
			case 3:speedMultiplier = 1.5f;
				break;
        }
	
    }

    // Update is called once per frame
    void Update()
    {
        if(SwapnTimer <= 0)
		{
			Drop();
			SwapnTimer = StartSwapnTime;
		}
		else
		{
			SwapnTimer -= Time.deltaTime;
		}
    }

	void Drop()
	{
		int i = Random.Range(0, spwanPoints.Length);
		int j = Random.Range(0, spwanPoints.Length);

		if(i == j)
		{
			GameObject go = Instantiate(obs, spwanPoints[i]);
			Rigidbody2D bod = go.GetComponent<Rigidbody2D>();
			bod.gravityScale = bod.gravityScale * speedMultiplier;
			Destroy(go, 10f);
		}
		else
		{
			GameObject go1 = Instantiate(obs, spwanPoints[i]);
			GameObject go2 = Instantiate(obs, spwanPoints[j]);
			Rigidbody2D bod1 = go1.GetComponent<Rigidbody2D>();
			bod1.gravityScale = bod1.gravityScale * speedMultiplier;
			Rigidbody2D bod2 = go2.GetComponent<Rigidbody2D>();
			bod2.gravityScale = bod2.gravityScale * speedMultiplier;
			Destroy(go1, 10f);
			Destroy(go2, 10f);
		}
	}
}
