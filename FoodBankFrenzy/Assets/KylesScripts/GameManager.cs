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
public class GameManager : Singleton<GameManager>
{
    //The UI Prefab.
    [SerializeField] private GameObject gameUI;

    //The timer object to keep track of game time.
    public Timer timer;

    //The UIManager to update UI.
    public UIManager uiManager { get; private set; }
    public BoxManager boxManager { get; private set; }

    //The current level in play.
    private int currentLevel = 0;
    private int previousLevel = 0;
    public int PreviousLevel { get { return previousLevel; } }
    public int nextLevel = -1; //Used to keep track of which scene to load after playing the InterGameplayScene.

    //True if play of the current level has begun.
    public bool levelStarted = false;
    private bool levelSetup = false;

    //The current level in play.
    public Level level { get; private set; }

    //cursor image
    //public Texture2D cursorTex;
    //public CursorMode cursorMode = CursorMode.Auto;

    //Audio vars
    public AudioSource audSrc;
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

            //If the game has been won, make sure to update GameOver as well.
            if (gameWon)
            {
                GameOver = true;
            }
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
                SpawnParticle("win", Vector2.zero);
                StartCoroutine(LoadLevelAfterGame(true));
            }
            else if (gameOver)
            {
                //The game is over and has been lost.
                uiManager.UpdateGameStatusText("You lose!");
                audSrc.PlayOneShot(lose);
                SpawnParticle("lose", Vector2.zero);
                StartCoroutine(LoadLevelAfterGame(false));
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
        audSrc = GetComponent<AudioSource>();

        //Cursor.SetCursor(cursorTex, Vector2.zero, cursorMode);
    }

    private void Start()
    {
        //Loads the current; useful for testing and NOT starting from the main menu scene.
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        SetupLevel();
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
        {
            print("[GameManager]: Level data could not be found.");
            return;
        }

        timer.time = level.LevelTime;

        //if (!level.IsTutorial)
        //    uiManager = Instantiate(gameUI).GetComponent<UIManager>();
        //else
        //    uiManager = FindObjectOfType<UIManager>();

        uiManager = FindObjectOfType<UIManager>();

        uiManager.SetupLevel(level);

        boxManager = FindObjectOfType<BoxManager>();
        boxManager.Setup();

        levelSetup = true;
    }

    private void Update()
    {
        if (Input.anyKeyDown && levelSetup && !levelStarted)
        {
            StartLevel();
        }
    }

    /// <summary>
    /// Loads the next level to be played.
    /// </summary>
    public void LoadLevel(int level, bool loadInterScene = false)
    {
        StartCoroutine(LoadLevelEnumerator(level, loadInterScene));
    }

    private IEnumerator LoadLevelAfterGame(bool gameWon)
    {
        previousLevel = currentLevel;
        yield return new WaitForSeconds(2f);

        if (gameWon)
            LoadLevel(8);
        else
            LoadLevel(9);
    }

    private IEnumerator LoadLevelEnumerator(int level, bool loadInterScene)
    {
        timer.Stop();
        currentLevel = level;

        //Make sure to reset all level-related variables before loading into the next one,
        //or else blobs of cans may spawn and the next level will start automatically.
        levelSetup = false;
        levelStarted = false;
        gameOver = false;
        gameWon = false;


        //Only load the InterGameplayScene between playable levels.
        if (loadInterScene)
        {
            nextLevel = currentLevel;
            currentLevel = 10;
        }

        //Start the fade animation.
        GameObject.FindGameObjectWithTag("Crossfader").GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1f);

        AsyncOperation ao = SceneManager.LoadSceneAsync(currentLevel, LoadSceneMode.Single);
        while(!ao.isDone)
        {
            print("Level Loading...");
            yield return null;
        }

        //Level loaded; Set it up.
        SetupLevel();
    }

    /// <summary>
    /// Begin the level.
    /// </summary>
    private void StartLevel()
    {
        levelStarted = true;
        uiManager.UpdateGameStatusText(string.Empty);

        //Spawn boxes at lvl start.
        for (int i = 0; i < level.MaxBoxes; ++i)
        {
            print("Spawning box " + (i+1));
            SpawnBox();
        }

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

    /// <summary>
    /// Spawns particle of type.
    /// </summary>
    /// <param name="particleType">The type of particle to spawn.</param>
    /// <param name="pos">Position of instantiation.</param>
    public void SpawnParticle(string particleType, Vector3 pos)
    {
        ParticleSystem particle = null;
        switch(particleType)
        {
            case "correct":
                particle = correctParticle;
                break;
            case "incorrect":
                particle = incorrectParticle;
                break;
            case "win":
                particle = winParticle;
                break;
            case "lose":
                particle = loseParticle;
                break;
            default:
                Debug.LogWarning("Particle type \'" + particleType + "\' not found!");
                return;
        }

        particle = Instantiate(particle, pos, particle.transform.rotation);
        particle.Play();
        Destroy(particle.gameObject, 1f);
    }
    
}