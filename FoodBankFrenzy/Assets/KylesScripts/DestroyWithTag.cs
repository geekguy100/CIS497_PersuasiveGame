/*****************************************************************************
// File Name :         DestroyWithTag.cs
// Author :            Kyle Grenier
// Creation Date :     10/21/2020
//
// Brief Description : Destroys any game object that enters its trigger
*****************************************************************************/
using UnityEngine;

public class DestroyWithTag : MonoBehaviour
{
    [SerializeField] private string theTag = "";

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(theTag))
            Destroy(col.gameObject);
    }
}