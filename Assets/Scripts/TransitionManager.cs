using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    [SerializeField]
    Text lives;
    [SerializeField]
    Text score;

    [Tooltip("Collection of Backgrounds")]
    [SerializeField]
    Sprite[] sprites;

    [SerializeField]
    GameObject[] dancers;

    SpriteRenderer rend;
    [SerializeField]
    GameObject poster;

    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
        score.text = "Score:" + manager.score.ToString();
        lives.text = "Lives:" + manager.lives.ToString();
        StartCoroutine("Transistion");
        rend = GetComponent<SpriteRenderer>();
        int backgroundNumber = Random.Range(0, sprites.Length);
        rend.sprite = sprites[backgroundNumber];
        if (backgroundNumber == 4) poster.SetActive(true);
        int number = Random.Range(0, dancers.Length);

        Debug.Log(number);

        for(int i = 0; i <= number; i++)
        {
            dancers[i].SetActive(true);
        }
    }


    IEnumerator Transistion()
    {
        yield return new WaitForSeconds(3f);
            manager.BeginGame();
    }
}
