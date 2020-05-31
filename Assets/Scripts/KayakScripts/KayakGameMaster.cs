using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KayakGameMaster : MonoBehaviour
{

	public GameObject obs;

	public Transform[] spwanPoints;

	public float SwapnTimer;
	public float StartSwapnTime;
    // Start is called before the first frame update
    void Start()
    {
	
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
			Destroy(go, 10f);
		}
		else
		{
			GameObject go1 = Instantiate(obs, spwanPoints[i]);
			GameObject go2 = Instantiate(obs, spwanPoints[j]);
			Destroy(go1, 10f);
			Destroy(go2, 10f);
		}
	}
}
