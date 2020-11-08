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

    public bool isStarted = false;

    private void Update()
    {
        if (GameManager.Instance.levelStarted)
        {
            if (!isStarted)
            {
                isStarted = true;
                InvokeRepeating("Spawn", delay, rate);
            }
        }
    }

    void Spawn()
    {
        y = Random.Range(yMax, yMin);
        foodIndex = Random.Range(0, food.Length);

        spawnPos = new Vector2(transform.position.x, y);

        Instantiate(food[foodIndex], spawnPos, food[foodIndex].transform.rotation);
    }
    

}
