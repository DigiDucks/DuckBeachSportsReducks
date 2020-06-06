using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives = 3;
    public int score = 0;

    public int goal = 8;

    AudioSource musicPlayer;

    [SerializeField]
    List<int> levelIndexes = new List<int>();
    List<int> playedGames = new List<int>();

    [SerializeField]
    AudioClip[] clips;

    [SerializeField]
    bool debugging = false;

    //Awake is called when the object is activated, before when the scene is loaded
    private void Awake()
    {

        //Checks to see if there is already a GameManager in Scene
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        for (int index = 5; index < SceneManager.sceneCountInBuildSettings; index++ )
        { 
            levelIndexes.Add(index);
        }

        musicPlayer = GetComponent<AudioSource>();

        if (debugging)
        {
            StartCoroutine("StartSequence");
        }
    }

    public void BeginTransistion()
    {
        SceneManager.LoadScene("TransistionScene");
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(PullLevel());
        StartCoroutine("StartSequence");
    }

    IEnumerator StartSequence()
    {   
        yield return new WaitForSeconds(0.5f);
        GameObject instruction = GameObject.FindGameObjectWithTag("UI");
        if ( instruction != null)
        {
            instruction.GetComponent<Animator>().Play("Entry");
        }
        yield return new WaitForSeconds(1f);
        if(FindObjectOfType<GameTemplate>() != null) FindObjectOfType<GameTemplate>().Begin();
        yield return new WaitForSeconds(2f);
        instruction.SetActive(false);
    }

    int PullLevel()
    {
        //If all the levels have been played, shuffle the order and play em again

        if (levelIndexes.Count <= 0)
        {
            Debug.Log("Shuffled");
            if (playedGames.Count != 0)
            {
                foreach (int num in playedGames)
                {
                    levelIndexes.Add(num);
                }
            }
            playedGames = new List<int>();
            for (int i = 0; i < levelIndexes.Count - 1; i++)
            {
                int randomIndex = Random.Range(i, levelIndexes.Count);
                int tempNum = levelIndexes[randomIndex];
                levelIndexes[randomIndex] = levelIndexes[i];
                levelIndexes[i] = tempNum;
            }
        }


        int nextLevel = 0;
        int pulledIndex = Random.Range(0, levelIndexes.Count - 1);
        nextLevel = levelIndexes[pulledIndex];
        playedGames.Add(nextLevel);
        levelIndexes.Remove(nextLevel);
        //Debug.Log(levelIndexes.Count);


        return nextLevel;
    }


    public void Won()
    {
        score++;
        if (score < goal)
        {
            musicPlayer.PlayOneShot(clips[0]);
            BeginTransistion();
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    public void Lost()
    {
        lives--;
        if (lives > 0)
        {
            musicPlayer.PlayOneShot(clips[1]);
            BeginTransistion();
        }
        else
        {
            SceneManager.LoadScene(3);
        }

    }



}
