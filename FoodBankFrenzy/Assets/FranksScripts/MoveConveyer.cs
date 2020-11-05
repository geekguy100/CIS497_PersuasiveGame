/*****************************************************************************
// File Name :         MoveConveyor.cs
// Author :            Frank Calabrese, Kyle Grenier
// Creation Date :     10/19/2020
//
// Brief Description : Moves the conveyor belt and any game objects tagged Item along with it.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;

public class MoveConveyer : MonoBehaviour
{
    public float speed = 5f;

    private List<Transform> itemsOnBelt = new List<Transform>();

    void Update()
    {
        if (GameManager.Instance.levelStarted)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);

            //Move each item on the belt.
            foreach (Transform item in itemsOnBelt)
                item.Translate(Vector2.right * speed * Time.deltaTime);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Item"))
            itemsOnBelt.Add(col.transform);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Item"))
            itemsOnBelt.Remove(col.transform);
    }

}
