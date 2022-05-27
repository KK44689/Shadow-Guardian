using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // check if game active
    public bool isGameActive { get; set; }

    // get player script
    PlayerController playerScript;

    // player animation
    Animator anim;

    // gameover screen
    public GameObject GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        playerScript =
            GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        GameOverScreen.SetActive(false);
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.s_currentHp <= 0)
        {
            isGameActive = false;
        }
        if (!isGameActive)
        {
            GameOverScreen.SetActive(true);
            anim.SetBool("damaged", true);
        }
    }
}
