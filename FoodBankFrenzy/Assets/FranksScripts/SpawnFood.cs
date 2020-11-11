using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject[] food;
    private int foodIndex;
    private Vector2 spawnPos;
    int previousIndex = -1; //The previous index of the spawned food item.
                            //Used so we don't spawn in the same food item multiple times in a row.

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
        int foodIndex;

        //If the food index is the same as the previous index, calculate another food index.
        do
        { 
            foodIndex = Random.Range(0, food.Length);

        } while (foodIndex == previousIndex);

        spawnPos = new Vector2(transform.position.x, y);

        Instantiate(food[foodIndex], spawnPos, food[foodIndex].transform.rotation);

        previousIndex = foodIndex; //Update the previousIndex to the foodIndex so we'll remember what we spawned in last cycle.
    }
    

}
