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
    public GameObject pickUpCamera;

    private void Start()
    {
        pickUpCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(theTag) && pickUpCamera.GetComponent<Pickup>().objectInHand != col.gameObject)
            Destroy(col.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag(theTag) && pickUpCamera.GetComponent<Pickup>().objectInHand != collision.gameObject)
        {
            Destroy(collision.gameObject);
        }
    }
}