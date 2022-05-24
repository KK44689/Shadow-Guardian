using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameActive { get; set; }

    PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        playerScript =
            GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.s_currentHp <= 0)
        {
            isGameActive = false;
        }
    }
}
