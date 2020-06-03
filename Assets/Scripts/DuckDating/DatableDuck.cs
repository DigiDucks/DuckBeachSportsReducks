using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class DatableDuck : MonoBehaviour
{
   public SpriteRenderer blush;
    DatingGameManager game;

    float opacity = 0;
    [SerializeField]
    float quackPotency = 1;

    private void Start()
    {
        game = FindObjectOfType<DatingGameManager>();
    }

    public void IncreaseBlush()
    {
        opacity += quackPotency;
        blush.color = new Color(1, 1, 1, opacity);
        if (opacity >= 1)
        {
            game.Win();
        }
    }

}
