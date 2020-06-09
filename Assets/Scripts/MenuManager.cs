using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    string[] konamiCode = new string[11] { "UpArrow", "UpArrow",
        "DownArrow", "DownArrow", "LeftArrow", "RightArrow", "LeftArrow", "RightArrow", "B", "A", "Return" };

    int currentPos = 0;

    bool inKonami = false;

    private void OnGUI()
    {
        Event e = Event.current;
        if(e.isKey && Input.anyKeyDown && !inKonami && e.keyCode.ToString() != "None")
        {
            KonamiFunction(e.keyCode);
        }
    }

    private void Update()
    {
        if (inKonami)
        {
            SceneManager.LoadScene(5);
        }
    }

    void KonamiFunction(KeyCode incomingKey)
    {
        string incomingKeyString = incomingKey.ToString();
        if (incomingKeyString == konamiCode[currentPos])
        {
            Debug.Log("Unlocked part " + (currentPos + 1) + "/" + konamiCode.Length + " with " + incomingKeyString);
            currentPos++;

            if ((currentPos + 1) > konamiCode.Length)
            {
                inKonami = true;
                currentPos = 0;
            }
        }
        else
        {
            Debug.Log("You fail Konami at position " + (currentPos + 1));
            currentPos = 0;
        }
    }
}
