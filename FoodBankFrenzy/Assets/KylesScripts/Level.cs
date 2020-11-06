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
    [SerializeField] private bool tutorial = false;
    public bool IsTutorial { get { return tutorial; } }

    //The score required to win the level.
    [SerializeField] private int maxScore = 0;
    public int MaxScore { get { return maxScore; } }
    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            ++score;
            GameManager.Instance.uiManager.UpdateNumBoxesText(maxScore - score);

            if (score >= maxScore)
            {
                GameManager.Instance.GameWon = true;
            }
        }
    }

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