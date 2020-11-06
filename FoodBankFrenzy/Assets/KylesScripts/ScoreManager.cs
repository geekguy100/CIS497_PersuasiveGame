/*****************************************************************************
// File Name :         ScoreManager.cs
// Author :            Kyle Grenier
// Creation Date :     10/30/2020
//
// Brief Description : A script that manages the player's score.
*****************************************************************************/
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //The score required to win the level.
    [SerializeField] private int maxScore = 0;
    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            ++score;

            if (score >= maxScore)
            {
                GameManager.Instance.GameWon = true;
            }
        }
    }

    public void SetupLevel()
    {
        score = 0;
    }
}