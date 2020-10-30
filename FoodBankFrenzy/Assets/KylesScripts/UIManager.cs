/*****************************************************************************
// File Name :         UIManager.cs
// Author :            Kyle Grenier
// Creation Date :     10/30/2020
//
// Brief Description : Script that manages and updates the UI.
*****************************************************************************/
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText = null;
    [SerializeField] private TextMeshProUGUI numBoxesText = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI gameStatusText = null;

    public void UpdateTimerText(float t)
    {
        timeText.text = "Timer: " + Mathf.CeilToInt(t);
    }

    public void UpdateScoreText(int s)
    {
        scoreText.text = "Score: " + s;
    }

    public void UpdateNumBoxesText(int s)
    {
        numBoxesText.text = "Number of Boxes: " + s;
    }

    public void UpdateGameStatusText(string t)
    {
        gameStatusText.text = t;
    }

    public void SetupLevel()
    {
        UpdateTimerText(0);
        UpdateScoreText(0);
        UpdateNumBoxesText(0);
        UpdateGameStatusText("Press any key to start.");
    }
}