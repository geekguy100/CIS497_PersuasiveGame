/*****************************************************************************
// File Name :         DestroyWithTag.cs
// Author :            Kyle Grenier, Frank Calabrese
// Creation Date :     10/21/2020
//
// Brief Description : Destroys any game object that enters its trigger
*****************************************************************************/
using UnityEngine;

public class DestroyWithTag : MonoBehaviour
{
    [SerializeField] private string theTag = "";
    private GameObject canInside = null;
    public GameObject pickUpCamera;

    private void Start()
    {
        pickUpCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(theTag) && CompareTag("MisclickDestroyer"))
        {
            canInside = col.gameObject;
        }

        if (col.CompareTag(theTag) && pickUpCamera.GetComponent<Pickup>().objectInHand != col.gameObject)
        {
            //Don't destroy the can that just entered the trigger if it's in the tetris spot.
            if (col.gameObject != pickUpCamera.GetComponent<Pickup>().itemHeld)
            {
                Destroy(col.gameObject);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(theTag) && CompareTag("MisclickDestroyer"))
        {
            canInside = null;
        }
    }

    private void Update()
    {
        //If we left click while a can is inside the trigger, meaning it's being held in our hand, destroy it b/c it's not being dropped
        //on a box. Don't destroy the can inside the trigger if it's being picked up from the tetris spot.
        if (Input.GetMouseButtonDown(0) && canInside && (canInside != pickUpCamera.GetComponent<Pickup>().itemHeld))
        {
            GameManager.Instance.SpawnParticle("incorrect", Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10));
            Destroy(canInside);
            FeedbackFaceManager.Instance.Animate(false);
            canInside = null;
        }

    }
}