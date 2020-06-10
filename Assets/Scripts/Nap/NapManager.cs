using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class NapManager : GameTemplate
{
    [SerializeField]
    AudioSource musicPlayer;
    AudioSource scratch;

    [SerializeField]
    SpriteRenderer duckSprite;

    [SerializeField]
    Sprite angrySprite;

    [SerializeField]
    float napTime = 7f;


    private void Start()
    {
        scratch = GetComponent<AudioSource>();
        switch (GameManager.instance.level)
        {
            case 1: napTime = 7f;
                break;
            case 2: napTime = 10f;
                break;
            case 3: napTime = 13f;
                break;
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            StopAllCoroutines();
            Lose();
        }
    }

    public override void Begin()
    {
        StartCoroutine("Nap");
    }

    public override void Lose()
    {
        StartCoroutine(LostBuffer());
    }

    public override void Win()
    {
        GameManager.instance.Won();
    }

    IEnumerator Nap()
    {
        yield return new WaitForSeconds(napTime);
        Win();
    }

    IEnumerator LostBuffer()
    {
        musicPlayer.Stop();
        duckSprite.sprite = angrySprite;
        scratch.PlayOneShot(scratch.clip);
        yield return new WaitForSeconds(1f);
        GameManager.instance.Lost();
    }

}
