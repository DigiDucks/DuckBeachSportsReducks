using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject smallSpawnObject;
    [SerializeField]
    GameObject ObastacleSpawnObject;
    [SerializeField]
    float smallTime, obsTime;
    [SerializeField]
    float upperBounds, lowerBounds;

    [SerializeField]
    Sprite[] starSprites;

    bool spawning0 = false;
    bool spawning1 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawning0)
        {
            StartCoroutine(SmallSpawn());
        }
        if (!spawning1)
        {
            StartCoroutine(ObstacleSpawn());
        }
    }

    IEnumerator SmallSpawn()
    {
        spawning0 = true;
        yield return new WaitForSeconds(smallTime);
        int amount = Random.Range(1, 10);
        for(int i =0; i < amount; i++)
        {
           GameObject obj = Instantiate(smallSpawnObject,
                new Vector3(transform.position.x,
                (transform.position.y + Random.Range(lowerBounds, upperBounds)), 0), transform.rotation);
            obj.GetComponent<SpriteRenderer>().sprite = starSprites[Random.Range(0, starSprites.Length)];

        }
        spawning0 = false;
    }

    IEnumerator ObstacleSpawn()
    {
        spawning1 = true;
        yield return new WaitForSeconds(obsTime);
        int _amount = Random.Range(1, 5);
        for(int j = 0; j < _amount; j++)
        {
            Instantiate(ObastacleSpawnObject, new Vector3(transform.position.x,
                (transform.position.y + Random.Range(lowerBounds, upperBounds)), 0), transform.rotation);
        }
        spawning1 = false;
    }
}
