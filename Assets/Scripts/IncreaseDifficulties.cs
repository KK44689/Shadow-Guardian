using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IncreaseDifficulties : MonoBehaviour
{
    [SerializeField]
    private float delayIncreaseDifficulties = 2f;

    // spawnManager script
    private SpawnManager spawnManagerScript;

    // good ending
    private float goodEndingDelay = 2f;

    private int goodEndingId = 5;

    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript =
            GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartCoroutine(DecreaseDelaysSpawnRate());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator DecreaseDelaysSpawnRate()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayIncreaseDifficulties);

            // Debug
            //     .Log("movable rate : " +
            //     spawnManagerScript.s_obstacleMovableSpawnRate);
            // Debug
            //     .Log("still rate : " +
            //     spawnManagerScript.s_obstacleStillSpawnRate);
            // check if movable spawn rate below zero
            if (spawnManagerScript.s_obstacleMovableSpawnRate <= 0.1f)
            {
                spawnManagerScript.s_obstacleMovableSpawnRate = 0.1f;
            }
            else
            {
                spawnManagerScript.s_obstacleMovableSpawnRate -= 0.1f;
            }

            // check if still spawn rate below zero
            if (spawnManagerScript.s_obstacleStillSpawnRate <= 1.5f)
            {
                spawnManagerScript.s_obstacleStillSpawnRate = 1.5f;
                StartCoroutine(GoodEnding());
            }
            else
            {
                spawnManagerScript.s_obstacleStillSpawnRate -= 0.1f;
            }
        }
    }

    IEnumerator GoodEnding()
    {
        yield return new WaitForSeconds(goodEndingDelay);
        SceneManager.LoadScene (goodEndingId);
    }
}
