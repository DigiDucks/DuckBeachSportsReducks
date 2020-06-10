using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverLoop : MonoBehaviour
{
    public float moveSpeed = 1f;

    float speedMultiplier = 1f;

    bool started = true;
    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.instance.level)
        {
            case 1:
                speedMultiplier = 1f;
                
                break;
            case 2:
                speedMultiplier = 1.2f;
                break;
            case 3:
                speedMultiplier = 1.5f;
                break;
        }
        moveSpeed *= speedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -15f)
        {
            if (started)
            {
                transform.position = new Vector2(0, transform.position.y - moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = new Vector2(0, 15f);
        }
    }
}
