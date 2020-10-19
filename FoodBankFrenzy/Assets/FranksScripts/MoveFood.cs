using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFood : MonoBehaviour
{
    public float speed = 5f;
    public float rightBound = 6.5f;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        if(transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }

}
