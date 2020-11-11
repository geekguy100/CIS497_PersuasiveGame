/* Frank Calabrese
 * We aren't using this anymore
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFood : MonoBehaviour
{
    public float speed = 5f;
    public float rightBound = 6.5f;
    public GameObject pickUpScript;

    private void Start()
    {
        pickUpScript = GameObject.FindGameObjectWithTag("MainCamera");
        
    }
    void Update()
    {
        if (transform.position.y >= -2 && transform.position.y <= 0 && pickUpScript.GetComponent<Pickup>().objectInHand != gameObject.GetComponent<Rigidbody2D>()) //AND NOT BEING PICKED UP
        { 
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        

        if(transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }

   

}
