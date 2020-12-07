/*****************************************************************************
// File Name :         Level.cs
// Author :            Kyle Grenier
// Creation Date :     11/6/2020
//
// Brief Description : Script to uniquely modify each level.
*****************************************************************************/
using UnityEngine;

public class Level : MonoBehaviour
{
    public TutorialTextScript TutorialScript;

    //The level to display on the UI.
    [SerializeField] private int levelNumber = -1;
    public int LevelNumber { get { return levelNumber; } }

    [SerializeField] private bool tutorial = false;
    public bool IsTutorial { get { return tutorial; } }

    //The score required to win the level.
    [SerializeField] private int maxBoxes = 0;
    public int MaxBoxes { get { return maxBoxes; } }

    //Number of boxes completed.
    public int score;

    private void Start()
    {
        TutorialScript = GameObject.FindGameObjectWithTag("TutorialText").GetComponent<TutorialTextScript>();
    }

    public int Score
    {
        get { return score; }
        set
        {
            ++score;
            GameManager.Instance.uiManager.UpdateNumBoxesText(maxBoxes - score);
            if(IsTutorial == true)
            {
                if(score >=maxBoxes && TutorialScript.isTutorialComplete == true)
                {
                    GameManager.Instance.GameWon = true;
                }
            }
            else
            {
                if (score >= maxBoxes)
                {
                    GameManager.Instance.GameWon = true;
                }
            }
        }
    }

    //How many box holders we are using for this level.
    [SerializeField] private int boxHoldersInUse = 3;
    public int BoxHoldersInUse { get { return boxHoldersInUse; } }

    //The time of the currently loaded level.
    [SerializeField] private float levelTime = 60f;
    public float LevelTime
    {
        get { return levelTime; }
    }

    //The min and max items to put into a box; the level's difficulty
    [SerializeField] private int minItems = 20;
    [SerializeField] private int maxItems = 20;
    public int MinItems
    { get
        { return minItems; }
    }
    public int MaxItems
    { get
        { return maxItems; }
    
    }
    
}