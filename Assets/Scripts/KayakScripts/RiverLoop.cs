using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverLoop : MonoBehaviour
{
    public float moveSpeed = 1f;

    bool started = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -14f)
        {
            if (started)
            {
                transform.position = new Vector2(0, transform.position.y - moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = new Vector2(0, 14f);
        }
    }
}
