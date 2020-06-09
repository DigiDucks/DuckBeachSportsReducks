using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives = 3;
    public int score = 0;

    public int level = 1;

    public int goal = 5;

    AudioSource musicPlayer;

    int lastLevel= 0;

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
        for (int index = 6; index < SceneManager.sceneCountInBuildSettings; index++ )
        { 
            levelIndexes.Add(index);
        }

        musicPlayer = GetComponent<AudioSource>();

        if (debugging)
        {
            StartCoroutine("StartSequence");
        }
    }

    public void BeginTransission()
    {
        SceneManager.LoadScene("TransistionScene");
    }

    public void BeginGame()
    {
        if (score >= goal)
        {
            SceneManager.LoadScene(4);
            StartCoroutine("StartSequence");
            return;
        }
        SceneManager.LoadScene(PullLevel());
        StartCoroutine("StartSequence");
    }

    int PullLevel()
    {
        //If all the levels have been played, shuffle the order and play em again

        if (levelIndexes.Count <= 0)
        {
            Shuffle();
        }
        

       int nextLevel = RandomLevel();

        if(nextLevel == lastLevel)
        {
            nextLevel = RandomLevel();
        }
        playedGames.Add(nextLevel);
        levelIndexes.Remove(nextLevel);
        //Debug.Log(levelIndexes.Count);
        lastLevel = nextLevel;

        return nextLevel;
    }

    void Shuffle()
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

    int RandomLevel()
    {
        int pulledIndex = Random.Range(0, levelIndexes.Count - 1);
        return levelIndexes[pulledIndex];
    }


    public void Won()
    {
        score++;
        Debug.Log("Won");
        musicPlayer.PlayOneShot(clips[0]);
        BeginTransission();
    }

    public void Lost()
    {
        lives--;
        if (lives > 0)
        {
            Debug.Log("Lost");
            musicPlayer.PlayOneShot(clips[1]);
            BeginTransission();
        }
        else
        {
            SceneManager.LoadScene(3);
        }

    }

    public void MainMenu()
    {
        lives = 3;
        score = 0;
        SceneManager.LoadScene(0);
    }

    public IEnumerator StartSequence()
    {
        yield return new WaitForSeconds(0.05f);
        GameObject instruction = GameObject.FindGameObjectWithTag("UI");
        if (instruction != null)
        {
            instruction.GetComponent<Animator>().Play("Entry");
        }
        yield return new WaitForSeconds(0.5f);
        if (FindObjectOfType<GameTemplate>() != null) FindObjectOfType<GameTemplate>().Begin();
        yield return new WaitForSeconds(3f);
        instruction.SetActive(false);
    }



}
