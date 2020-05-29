using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameTemplate : MonoBehaviour
{
    [SerializeField] string instructions = "Do a thing to win the game";

    public abstract void Begin();

    public abstract void Lose();

    public abstract void Win();
}
