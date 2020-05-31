using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingRoad : MonoBehaviour
{
    public Vector3 movementSpeed = new Vector3(-2f, 0);
    public Vector3 offScreenTeleportPosition = new Vector3(13, -0.5f);
    public List<GameObject> obstacles;
    public List<GameObject> spawnedObstacles;

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

    // Called when object becomes invisible
    private void OnBecameInvisible()
    {


        // Murder children
        for (int i = 0; i < spawnedObstacles.Count; ++i)
        {
            Destroy(spawnedObstacles[i]);
        }
        spawnedObstacles.Clear();

        GameObject road_obstacle = Instantiate(obstacles[0]);
        road_obstacle.transform.SetParent(this.transform);
        road_obstacle.transform.localPosition = new Vector3(Random.Range(-1, 1), 0.4f, 0);
        spawnedObstacles.Add(road_obstacle);

        // Reset road after it goes offscreen
        transform.position = offScreenTeleportPosition;
    }
}
