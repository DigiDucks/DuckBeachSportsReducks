using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatePlayer : MonoBehaviour
{

    AudioSource quackSFX;
    DatableDuck date;

    public GameObject quackBubble;

    // Start is called before the first frame update
    void Start()
    {
        quackSFX = GetComponent<AudioSource>();
        date = FindObjectOfType<DatableDuck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            quackSFX.PlayOneShot(quackSFX.clip);
            date.IncreaseBlush();
            StartCoroutine("QuackBubble");
        }
    }
    IEnumerator QuackBubble()
    {
        quackBubble.SetActive(true);
        yield return new WaitForSeconds(.35f);
        quackBubble.SetActive(false);
    }
}
