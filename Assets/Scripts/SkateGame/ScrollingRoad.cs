using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingRoad : MonoBehaviour
{
    public Vector3 movementSpeed = new Vector3(-2f, 0);
    public Vector3 offScreenTeleportPosition = new Vector3(13, -0.5f);

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
        // Reset road after it goes offscreen
        transform.position = offScreenTeleportPosition;
    }
}
