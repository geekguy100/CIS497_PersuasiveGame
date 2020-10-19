using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConveyer : MonoBehaviour
{
    public float speed = 5f;
    private float rightBound;

    void Start()
    {
        rightBound = gameObject.GetComponent<BoxCollider2D>().size.x;
}
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
