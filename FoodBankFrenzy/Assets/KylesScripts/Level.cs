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