using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Obstacles;

    private float obstacleSpawnRate = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacles");
    }

    // Update is called once per frame
    void Update()
    {
    }

    // random the obstacle's type
    int RandomObstaclesIndex()
    {
        int index = Random.Range(0, Obstacles.Length);
        return index;
    }

    // random the obstacle spawn pos
    Vector3 GenRandomSpawnPos()
    {
        float spawnPosY = Random.Range(-3f, 5.2f);
        float[] spawnPosX = new float[] { -9f, 10f };
        int spawnXIndex = Random.Range(0, 2);
        return new Vector3(spawnPosX[spawnXIndex], spawnPosY, 0);
    }

    // random obstacle rotation degree
    Quaternion GenRandomRotation()
    {
        float rotationZ = Random.Range(0, 360);
        return Quaternion.Euler(0, 0, rotationZ);
    }

    float RandomSpawnRate()
    {
        float spawnRate = Random.Range(0, obstacleSpawnRate);
        return spawnRate;
    }

    // spawn obstacle
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Instantiate(Obstacles[RandomObstaclesIndex()],
            GenRandomSpawnPos(),
            GenRandomRotation());
            yield return new WaitForSeconds(RandomSpawnRate());
        }
    }
}
