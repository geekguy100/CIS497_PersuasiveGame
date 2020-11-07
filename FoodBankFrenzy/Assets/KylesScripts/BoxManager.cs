/*****************************************************************************
// File Name :         BoxManager.cs
// Author :            Kyle Grenier
// Creation Date :     11/3/2020
//
// Brief Description : Manages creating and tweening boxes.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;

public class BoxManager : MonoBehaviour
{
    //The box prefab to be instantiated.
    [SerializeField] private BoxBehaviour boxPrefab;
    [SerializeField] private Level level;

    //Parallel arrays: The spawning locations and locations the box should tween to, respectively.
    [SerializeField] private Transform[] spawnLocations;
    [SerializeField] private Transform[] finalLocations;
    private bool[] locationsAvailable;
    public int boxesActive = 0;

    //The boxes on standby that want to be spawned but cannot be.
    private int waitingBoxes = 0;

    private void Awake()
    {
        locationsAvailable = new bool[spawnLocations.Length];

        //Set all locations to available.
        for (int i = 0; i < locationsAvailable.Length; ++i)
            locationsAvailable[i] = true;

        if (spawnLocations.Length != finalLocations.Length)
            Debug.LogWarning("[BoxManager]: The spawnLocations and finalLocations are not of equal length!");
    }

    /// <summary>
    /// Instantiates a new box prefab and tweens it towards the first available position.
    /// </summary>
    /// <param name="minItems">The minimum number of items that the box should need.</param>
    /// <param name="maxItems">The maximum number of items that the box should need.</param>
    public void InstantiateBox(int minItems, int maxItems)
    {
        int i;

        //Get the next available location.
        for (i = 0; i < spawnLocations.Length; ++i)
        {
            if (locationsAvailable[i]) //&& boxesActive < level.MaxScore)
                break;
        }

        //There are currently no available spots for the box to spawn at.
        //Update counter.
        if (i >= spawnLocations.Length)
        {
            print("[BoxManager]: All available positions are full. Increasing waiting count.");

            ++waitingBoxes;
            return;
        }

        //Instantiate the box
        BoxBehaviour box = Instantiate(boxPrefab, spawnLocations[i].position, Quaternion.identity);
        box.Init(minItems, maxItems, i);

        //Tween the box to location.
        TweenObject(box.gameObject, finalLocations[i].position, 1f);

        locationsAvailable[i] = false;
        boxesActive++;
    }

    /// <summary>
    /// Tweens the box to location in time 'time'.
    /// </summary>
    /// <param name="box">The box to be tweened.</param>
    /// <param name="pos">The position to be tweened to.</param>
    /// <param name="time">The time over which the tweening will occur.</param>
    private void TweenObject(GameObject box, Vector3 pos, float time)
    {
        iTween.MoveTo(box, iTween.Hash
            ("position", pos, 
            "time", time, 
            "oncompletetarget", box, 
            "oncomplete", "Open",
            "easetype", "easeOutExpo"));
    }

    /// <summary>
    /// Increase the score and see if there are any boxes on standby to spawn.
    /// </summary>
    public void OnBoxFinish(BoxBehaviour box)
    {
        GameManager.Instance.level.Score++;
        boxesActive--;
        locationsAvailable[box.ID] = true;
        box.Close();
        GameManager.Instance.audSrc.PlayOneShot(GameManager.Instance.complete, 1f);
        //TODO: Tween the box off screen. For now I'm just destroying it.
        Destroy(box.gameObject, 1f);

        if (waitingBoxes > 0)
        {
            --waitingBoxes;
            GameManager.Instance.SpawnBox();
        }
    }
}