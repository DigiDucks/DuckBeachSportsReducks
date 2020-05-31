using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetSwitch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.GetComponent<BallMovement>() != null)
        {
            BallMovement ball = collision.GetComponent<BallMovement>();
            if (ball.returned)
            {
                ball.rend.sortingOrder = 1;
            }
            else
            {
                ball.rend.sortingOrder = 3;
            }
        }
    }
}
