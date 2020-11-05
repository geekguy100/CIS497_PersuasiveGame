using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatConveyerSprite : MonoBehaviour
{
    private Vector2 startPos;
    private float width;
    private float offset = 2.08f;//2.5f;

   
    void Start()
    {
        startPos = transform.position;
        width = GetComponent<BoxCollider2D>().size.x / offset;
    }

    void Update()
    {
        if ( transform.position.x > startPos.x + width)
        {
            transform.position = startPos;
        }
    }
}
