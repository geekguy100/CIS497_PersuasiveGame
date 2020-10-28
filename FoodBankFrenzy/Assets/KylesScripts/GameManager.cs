/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Kyle Grenier
// Creation Date :     10/28/2020
//
// Brief Description : Script to manage the game state.
*****************************************************************************/
using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    //An array of individual level's play times.
    [SerializeField] private float[] levelTimes;

    //The time of the currently loaded level.
    private float levelTime;

    //The timer object to keep track of game time.
    public Timer timer { get; private set; }

    //The current level in play.
    private int currentLevel = 0;

    //True if play of the current level has begun.
    private bool levelStarted = false;

    protected override void Awake()
    {
        base.Awake();

        //Keep the GameManager persistent throughout the entire game.
        DontDestroyOnLoad(gameObject);

        timer = GetComponent<Timer>();
    }

    /// <summary>
    /// Loads the next level to be played.
    /// </summary>
    private void LoadLevel(int level)
    {
        currentLevel = level;
        //TODO: Load a new level using SceneManager.
        levelTime = levelTimes[currentLevel];
        timer.time = levelTime;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !levelStarted)
        {
            LoadLevel(0);
            StartCoroutine("StartLevel");
        }
    }

    /// <summary>
    /// Begin a level by waiting 3 seconds then starting the timer.
    /// </summary>
    private IEnumerator StartLevel()
    {
        //TODO: Update UI to show user what's going on.
        int t = 3;
        while (t > 0)
        {
            //Display UI
            print(t);
            yield return new WaitForSeconds(1f);
            --t;
        }

        levelStarted = true;
        timer.BeginCountdown();
    }
}