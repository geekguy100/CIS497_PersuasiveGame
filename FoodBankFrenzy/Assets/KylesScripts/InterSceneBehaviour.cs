/*****************************************************************************
// File Name :         InterSceneBehaviour.cs
// Author :            Kyle Grenier
// Creation Date :     11/11/2020
//
// Brief Description : Waits and then loads the nextLevel in the GameManager.
*****************************************************************************/
using UnityEngine;
using System.Collections;

public class InterSceneBehaviour : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitAndLoad());
    }

    /// <summary>
    /// Wait some amount of time before loading the nextLevel from the GameManager.
    /// </summary>
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(5f);
        GameManager.Instance.LoadLevel(GameManager.Instance.nextLevel);
    }
}