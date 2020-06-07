using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{
    Animator anim;

    string[] dances = new string[3] { "TheBounce", "SideToSide", "TheLean" };

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.Play(dances[Random.Range(0, dances.Length)]);

    }
}
