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
        {
            //If this game object destroys misclicked cans and is NOT the conveyor belt destroyer, play a particle effect at mouse position.
            //Adding 10 to mousePos b/c it defaults to a Z of -10.
            if (CompareTag("MisclickDestroyer"))
                GameManager.Instance.SpawnParticle("incorrect", Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10));
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag(theTag) && pickUpCamera.GetComponent<Pickup>().objectInHand != collision.gameObject)
        {
            //If this game object destroys misclicked cans and is NOT the conveyor belt destroyer, play a particle effect at mouse position.
            //Adding 10 to mousePos b/c it defaults to a Z of -10.
            if (CompareTag("MisclickDestroyer"))
                GameManager.Instance.SpawnParticle("incorrect", Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10));
            Destroy(collision.gameObject);
        }
    }
}