using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject[] food;
    private int foodIndex;
    private Vector2 spawnPos;

    public float yMax = -0.5f;
    public float yMin = -2f;

    public float delay = 2;
    public float rate = 2;

    private float y;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);
    }

    void Spawn()
    {
        y = Random.Range(yMax, yMin);
        foodIndex = Random.Range(0, food.Length);

        spawnPos = new Vector2(transform.position.x, y);

        Instantiate(food[foodIndex], spawnPos, food[foodIndex].transform.rotation);
    }

}
