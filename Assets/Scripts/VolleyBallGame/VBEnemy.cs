using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VBEnemy : MonoBehaviour
{
    BallMovement ball;
    bool moving = false;

    Vector3 movePosition;

    public float moveSpeed = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<BallMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if(!Mathf.Approximately(transform.position.x, movePosition.x))
            {
                transform.position = Vector2.MoveTowards(transform.position, movePosition, moveSpeed * Time.deltaTime);
            }
            else
            {
                moving = false;
            }
        }
    }

    public void SetMove(Vector3 position)
    {
        movePosition = position;
        moving = true;
    }
}
