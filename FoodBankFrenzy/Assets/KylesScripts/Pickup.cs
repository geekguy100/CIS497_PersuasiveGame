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
    public GameObject objectInHand = null;

    //Audio
    public AudioClip grab;
    public AudioClip drop;
    public AudioSource audSrc;

    private void Awake()
    {
        audSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Don't allow items to be picked up after the game has ended.
        if (GameManager.Instance.GameOver)
            return;

        //Check to see if there's an object we can pick up on mouse click if we don't have one in our hand.
        if (Input.GetButtonDown("Fire1") && objectInHand == null)
            CheckForObject();
        //Drop the object if we have something in our hand.
        else if (Input.GetButtonDown("Fire1") && objectInHand != null)
            DropObject();
        //If all other conditions fail, move the object to the mouse position.
        else if (objectInHand != null)
            MoveObject();
    }

    private void CheckForObject()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

        if (hit && hit.transform.CompareTag("Item"))
        {
            objectInHand = hit.transform.gameObject;
            audSrc.PlayOneShot(grab);
        }
    }

    private void MoveObject()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objectInHand.transform.position = mousePos;
    }

    private void DropObject()
    {
        objectInHand = null;
        audSrc.PlayOneShot(drop);
    }
}