using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
	[Header("Attack Timer")]
	[SerializeField] private Transform eyeBlast;
	[SerializeField] private Transform chestBlast;

	[SerializeField] private GameObject greenBeam;
	[SerializeField] private GameObject fireBlast;

	
	[SerializeField] private float startTimer;
	[SerializeField] private float timer;

	[Header("Boss's Health")]
	[SerializeField] private Slider healthBar;
	[SerializeField] private float maxHealth;
	[SerializeField] private float health;

	public GameObject waterEffect;

	AudioManager audioManager;
	GameManager manager;

	float speedMultiplier = 1f;

	// Start is called before the first frame update
	void Start()
    {
		timer = startTimer;
		healthBar.maxValue = maxHealth;
		manager = GameManager.instance;
		audioManager = AudioManager.instance;

        switch (manager.level)
        {
			case 1: speedMultiplier = 1f;
				break;
			case 2: speedMultiplier = 0.85f;
				break;
			case 3: speedMultiplier = 0.7f;
				break;
        }
    }

    // Update is called once per frame
    void Update()
    {
		healthBar.value = health;

        if(timer <= 0)
		{
			Shoot(Random.Range(0, 2));
			timer = startTimer;
		}
		else
		{
			timer -= Time.deltaTime;
		}

		if(health <= 0)
		{
			Win();
		}
    }

	void Win()
	{

		if (manager.level > 2)
		{
			manager.PauseTimer();
			SceneManager.LoadScene(2);
		}
        else
        {
			manager.lives++;
			manager.goal += 6;
			manager.level++;
			manager.Won();
        }
	}

	void Shoot(int Pick)
	{
		if(Pick == 1)
		{
			StartCoroutine(DoTheBlast(eyeBlast, greenBeam));
			audioManager.Play("laser");
		}
		else
		{
			audioManager.Play("Fire");
			StartCoroutine(DoTheBlast(chestBlast, fireBlast));
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "PlayerBlast")
		{
			StartCoroutine("Flash");
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "PlayerBlast")
		{
			FindObjectOfType<AudioManager>().Play("hurt");
			StartCoroutine("Flash");
			Destroy(collision.gameObject);
			GameObject go = Instantiate(waterEffect, collision.transform.position, Quaternion.identity);
			Destroy(go, 0.1f);
		}
	}

	IEnumerator Flash()
	{
		health--;
		GetComponent<SpriteRenderer>().color = Color.red;
		yield return new WaitForSeconds(0.1f);
		GetComponent<SpriteRenderer>().color = Color.white;
	}

	IEnumerator DoTheBlast(Transform trans, GameObject blast)
	{
		trans.GetComponent<Animator>().SetTrigger("glow");
		yield return new WaitForSeconds(0.3f*speedMultiplier);
		Instantiate(blast, trans.position, Quaternion.identity);
		yield return null;
	}
	
}
