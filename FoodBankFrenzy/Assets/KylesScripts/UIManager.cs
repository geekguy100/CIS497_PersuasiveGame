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
    [SerializeField] private TextMeshProUGUI gameStatusText = null;
    [SerializeField] private TextMeshProUGUI levelText = null;

    public void UpdateTimerText(float t)
    {
        timeText.text = "        X " + Mathf.CeilToInt(t);
    }

    public void UpdateNumBoxesText(int s)
    {
        numBoxesText.text = "X " + s;
    }

    public void UpdateGameStatusText(string t)
    {
        gameStatusText.text = t;
    }

    private void SetLevelText(int l)
    {
        if (l == -1)
        {
            levelText.text = "Tutorial";
        }
        else
        {
            levelText.text = "Level: " + l;
        }
    }

    public void SetupLevel(Level l)
    {
        UpdateTimerText(l.LevelTime);
        UpdateNumBoxesText(l.MaxBoxes);
        SetLevelText(l.LevelNumber);
        UpdateGameStatusText("Press any key to start.");
    }
}