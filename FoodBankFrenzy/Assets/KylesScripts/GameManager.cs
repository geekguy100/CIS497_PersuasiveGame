/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Kyle Grenier
// Creation Date :     10/28/2020
//
// Brief Description : Script to manage the game state.
*****************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(ScoreManager))]
public class GameManager : Singleton<GameManager>
{
    //The UI Prefab.
    [SerializeField] private GameObject gameUI;

    //The timer object to keep track of game time.
    private Timer timer;
    //The ScoreManager to keep track of the score.
    public ScoreManager scoreManager { get; private set; }

    //The UIManager to update UI.
    public UIManager uiManager { get; private set; }
    public BoxManager boxManager { get; private set; }

    //The current level in play.
    private int currentLevel = 0;
    //True if play of the current level has begun.
    public bool levelStarted = false;
    private bool levelSetup = false;

    //The current level in play.
    private Level level;

    //cursor image
    public Texture2D cursorTex;
    public CursorMode cursorMode = CursorMode.Auto;

    //Audio vars
    public AudioSource audSrc;
    public AudioClip bgMusic;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip correct;
    public AudioClip incorrect;
    public AudioClip complete;

    //Particle
    public ParticleSystem winParticle;
    public ParticleSystem loseParticle;
    public ParticleSystem correctParticle;
    public ParticleSystem incorrectParticle;

    private bool gameOver = false;
    private bool gameWon = false;
    public bool GameWon
    {
        get { return gameWon; }
        set
        {
            gameWon = value;

            //Uncommenting the below code will make the game end upon achieving the max score.

            //If the game has been won, make sure to update GameOver as well.
            //if (gameWon)
            //{
            //    GameOver = true;
            //}
        }
    }
    public bool GameOver
    {
        get { return gameOver; }
        set
        {
            gameOver = value;
            if (gameOver && gameWon)
            {
                //The game has been won.
                uiManager.UpdateGameStatusText("You win!");
                audSrc.PlayOneShot(win);
                winParticle.Play();
            }
            else if (gameOver)
            {
                //The game is over and has been lost.
                uiManager.UpdateGameStatusText("You lose!");
                audSrc.PlayOneShot(lose);
                loseParticle.Play();
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();

        //Keep the GameManager persistent throughout the entire game.
        DontDestroyOnLoad(gameObject);

        //Get required components
        timer = GetComponent<Timer>();
        scoreManager = GetComponent<ScoreManager>();
        uiManager = GetComponent<UIManager>();
        audSrc = GetComponent<AudioSource>();

        Cursor.SetCursor(cursorTex, Vector2.zero, cursorMode);
    }

    private void Start()
    {
        audSrc.PlayOneShot(bgMusic);
    }

    /// <summary>
    /// Setup the current level by re-initializing level time and timer.
    /// Also, call SetupLevel() in the ScoreManager and UIManager.
    /// </summary>
    private void SetupLevel()
    {
        level = FindObjectOfType<Level>();

        //If there is no level found, we're on a menu scene.
        if (level == null)
            return;

        timer.time = level.LevelTime;
        scoreManager.SetupLevel();

        if (!level.IsTutorial)
            uiManager = Instantiate(gameUI).GetComponent<UIManager>();
        else
            uiManager = FindObjectOfType<UIManager>();

        uiManager.SetupLevel();
        boxManager = FindObjectOfType<BoxManager>();

        levelSetup = true;
    }

    private void Update()
    {
        if (Input.anyKeyDown && levelSetup && !levelStarted)
        {
            StartLevel();
        }

        //Debugging purposes
        if (Input.GetKeyDown(KeyCode.Return) && levelStarted)
            SpawnBox();
    }

    /// <summary>
    /// Loads the next level to be played.
    /// </summary>
    public void LoadLevel(int level)
    {
        currentLevel = level;
        SceneManager.LoadScene(level);
        SetupLevel();
    }

    /// <summary>
    /// Begin a level by waiting 3 seconds then starting the timer.
    /// </summary>
    private void StartLevel()
    {
        levelStarted = true;
        uiManager.UpdateGameStatusText(string.Empty);
        timer.BeginCountdown();
    }

    //TODO: Should a box spawn in a replacement once it is finished being filled up?
    //Should there be a queue that fills when all of the available positions are filled?
    public void SpawnBox()
    {
        if (!levelStarted)
        {
            Debug.LogWarning("[GameManager]: Trying to spawn a box when the level isn't started.");
            return;
        }

        boxManager.InstantiateBox(level.MinItems, level.MaxItems );
    }
}