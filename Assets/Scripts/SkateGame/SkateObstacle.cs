using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateObstacle : MonoBehaviour
{
    public Vector3 movementSpeed = new Vector3(-2f, 0);
    public Vector3 offScreenTeleportPosition = new Vector3(13, -0.5f);
    public int spawnDeviationMax = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move road
        transform.position += movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            int spawnDeviation = Random.Range(0, spawnDeviationMax);
            int spawnOrDelete = Random.Range(1, 5);
            if (spawnOrDelete == 1)
            {
                offScreenTeleportPosition.x += spawnDeviation;
                transform.position = offScreenTeleportPosition;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
