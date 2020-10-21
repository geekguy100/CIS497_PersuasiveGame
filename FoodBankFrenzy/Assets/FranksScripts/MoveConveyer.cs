/*****************************************************************************
// File Name :         MoveConveyor.cs
// Author :            Frank Calabrese, Kyle Grenier
// Creation Date :     10/19/2020
//
// Brief Description : Moves the conveyor belt and any game objects tagged Item along with it.
*****************************************************************************/
using UnityEngine;

public class MoveConveyer : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }


    //TODO: Since items appear jittery, try making a list of <Transform> and in Update move the items using a foreach().
    private void OnTriggerStay2D(Collider2D col)
    {
        //If the item that entered the trigger is an Item that can be moved, move it along.
        if (col.CompareTag("Item"))
        {
            col.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }


}
