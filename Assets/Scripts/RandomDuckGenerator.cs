using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDuckGenerator : MonoBehaviour
{
    [SerializeField]
    List<Sprite> ducks = new List<Sprite>();

    SpriteRenderer _rend;

    // Start is called before the first frame update
    void Awake()
    {
        _rend = GetComponent<SpriteRenderer>();
        GenerateDuck();
    }
    
    public void GenerateDuck()
    {
        _rend.sprite = ducks[Random.Range(0, ducks.Count)];
    }
}
