/*****************************************************************************
// File Name :         BoxManager.cs
// Author :            Kyle Grenier
// Creation Date :     11/3/2020
//
// Brief Description : Manages creating and tweening boxes.
*****************************************************************************/
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    //The box prefab to be instantiated.
    [SerializeField] private BoxBehaviour boxPrefab;

    //Parallel arrays: The spawning locations and locations the box should tween to, respectively.
    [SerializeField] private Transform[] spawnLocations;
    [SerializeField] private Transform[] finalLocations;
    private bool[] locationAvailable;

    private void Awake()
    {
        locationAvailable = new bool[spawnLocations.Length];

        if (spawnLocations.Length != finalLocations.Length)
            Debug.LogWarning("[BoxManager]: The spawnLocations and finalLocations are not of equal length!");
    }

    /// <summary>
    /// Instantiates a new box prefab and tweens it towards the first available position.
    /// </summary>
    /// <param name="minItems">The minimum number of items that the box should need.</param>
    /// <param name="maxItems">The maximum number of items that the box should need.</param>
    public BoxBehaviour InstantiateBox(int minItems, int maxItems)
    {
        int i;

        for (i = 0; i < spawnLocations.Length; ++i)
        {
            if (locationAvailable[i])
                break;
        }

        BoxBehaviour box = Instantiate(boxPrefab, spawnLocations[i].position, Quaternion.identity);
        box.Init(minItems, maxItems);
    }

    private bool CanSpawnBox()
    {
        foreach (bool b in locationAvailable)
        {
            if (b == true)
                return true;
        }

        return false;
    }
}