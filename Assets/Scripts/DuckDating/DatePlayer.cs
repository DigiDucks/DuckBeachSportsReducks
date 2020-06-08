using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatePlayer : MonoBehaviour
{

    AudioSource quackSFX;
    AudioClip quack;
    DatableDuck date;

    public GameObject quackBubble;

    [SerializeField]
    AudioClip[] normalQuacks;
    [SerializeField]
    AudioClip[] cursedQuacks;

    // Start is called before the first frame update
    void Start()
    {
        quackSFX = GetComponent<AudioSource>();
        date = FindObjectOfType<DatableDuck>();
        quack = normalQuacks[Random.Range(0, normalQuacks.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            quackSFX.PlayOneShot(QuackGenerator());
            date.IncreaseBlush();
            StartCoroutine("QuackBubble");
        }
    }

    AudioClip QuackGenerator()
    {
        int random = Random.Range(1, 10);
        if (random > 8)
        {
            return cursedQuacks[Random.Range(0, cursedQuacks.Length)];
        }
        else
        {
            return quack;
        }
    }


    IEnumerator QuackBubble()
    {
        quackBubble.SetActive(true);
        yield return new WaitForSeconds(.35f);
        quackBubble.SetActive(false);
    }
}
