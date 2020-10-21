/*****************************************************************************
// File Name :         Pickup.cs
// Author :            Kyle Grenier
// Creation Date :     10/19/2020
//
// Brief Description : Enables player to use mouse to pick and drop rigidbodies.
*****************************************************************************/
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //The Rigidbody2D we are holding.
    public Rigidbody2D objectInHand = null;

    private void Update()
    {
        //Check to see if there's an object we can pick up on mouse click if we don't have one in our hand.
        if (Input.GetButtonDown("Fire1") && objectInHand == null)
            CheckForObject();
        //Drop the object if we have something in our hand.
        else if (Input.GetButtonDown("Fire1") && objectInHand != null)
            DropObject();
    }

    private void FixedUpdate()
    {
        //Keep the grabbed rigidbody at the mouse's position.
        if (objectInHand != null)
            MoveObject();
    }

    private void CheckForObject()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

        //If what we hit has a Rigidbody2D, we can pick it up.
        if (hit.rigidbody)
        {
            objectInHand = hit.rigidbody;
        }
    }

    private void MoveObject()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objectInHand.MovePosition(mousePos);
    }

    private void DropObject()
    {
        objectInHand = null;
    }
}