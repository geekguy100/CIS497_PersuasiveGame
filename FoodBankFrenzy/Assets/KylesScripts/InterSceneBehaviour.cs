/*****************************************************************************
// File Name :         InterSceneBehaviour.cs
// Author :            Kyle Grenier
// Creation Date :     11/11/2020
//
// Brief Description : Waits and then loads the nextLevel in the GameManager.
*****************************************************************************/
using UnityEngine;

public class InterSceneBehaviour : MonoBehaviour
{
    private bool transitioned = false;
    void Update()
    {
        if (!transitioned && Input.anyKey)
        {
            transitioned = true;
            GameManager.Instance.LoadLevel(GameManager.Instance.nextLevel);
        }
    }
}