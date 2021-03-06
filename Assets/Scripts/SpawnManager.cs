using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] movableObstacles;

    public GameObject[] stillObstacles;

    private float obstacleMovableSpawnRate = 3f;

    public float s_obstacleMovableSpawnRate
    {
        get
        {
            return obstacleMovableSpawnRate;
        }
        set
        {
            if (value < 0)
            {
                Debug
                    .LogError("You can't set obstacleMovableSpawnRate below zero!");
            }
            else
            {
                obstacleMovableSpawnRate = value;
            }
        }
    }

    private float obstacleStillSpawnRate = 10f;

    public float s_obstacleStillSpawnRate
    {
        get
        {
            return obstacleStillSpawnRate;
        }
        set
        {
            if (value < 0)
            {
                Debug
                    .LogError("You can't set obstacleMovableSpawnRate below zero!");
            }
            else
            {
                obstacleStillSpawnRate = value;
            }
        }
    }

    // spawn movable obstacle pos
    float minSpawnPosY = -3f;

    float maxSpawnPosY = 5.2f;

    float minSpawnPosX = -9f;

    float maxSpawnPosX = 10f;

    // spawn still obstacle pos
    float spawnStillPosX = 10f;

    float spawnStillPosY = -1f;

    // gameManager
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine("SpawnMovableObstacles");
        StartCoroutine("SpawnStillObstacles");
    }

    // Update is called once per frame
    void Update()
    {
    }

    // random the obstacle's type
    int RandomObstaclesIndex(GameObject[] obstacles)
    {
        int index = Random.Range(0, obstacles.Length);
        return index;
    }

    // random the movable obstacle spawn pos
    Vector3 GenRandomSpawnMovablePos()
    {
        float spawnPosY = Random.Range(minSpawnPosY, maxSpawnPosY);
        float spawnPosX = Random.Range(minSpawnPosX, maxSpawnPosX);

        // int spawnXIndex = Random.Range(0, 2);
        if (spawnPosX > minSpawnPosX || spawnPosX < maxSpawnPosX)
        {
            spawnPosY = 6f;
        }
        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    // generate the still obstacle spawn pos
    Vector3 GenSpawnStillPos()
    {
        return new Vector3(spawnStillPosX, spawnStillPosY, 0);
    }

    // random obstacle rotation degree
    Quaternion GenRandomRotation()
    {
        float rotationZ = Random.Range(0, 360);
        return Quaternion.Euler(0, 0, rotationZ);
    }

    // random obstacle spawn rate
    float RandomSpawnRate(float maxSpawnRate)
    {
        float spawnRate = Random.Range(1f, maxSpawnRate);
        return spawnRate;
    }

    // spawn obstacle
    IEnumerator SpawnMovableObstacles()
    {
        while (gameManager.isGameActive)
        {
            Instantiate(movableObstacles[RandomObstaclesIndex(movableObstacles)],
            GenRandomSpawnMovablePos(),
            GenRandomRotation());
            yield return new WaitForSeconds(RandomSpawnRate(obstacleMovableSpawnRate));
        }
    }

    IEnumerator SpawnStillObstacles()
    {
        while (gameManager.isGameActive)
        {
            Instantiate(stillObstacles[RandomObstaclesIndex(stillObstacles)],
            GenSpawnStillPos(),
            stillObstacles[RandomObstaclesIndex(stillObstacles)]
                .transform
                .rotation);
            yield return new WaitForSeconds(RandomSpawnRate(obstacleStillSpawnRate));
        }
    }
}
