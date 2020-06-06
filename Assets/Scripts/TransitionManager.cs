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

    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
        score.text = "Score:" + manager.score.ToString();
        lives.text = "Lives:" + manager.lives.ToString();
        StartCoroutine("Transistion");
    }


    IEnumerator Transistion()
    {
        yield return new WaitForSeconds(3f);
        manager.BeginGame();
    }
}
