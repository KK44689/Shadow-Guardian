using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // check if game active
    public bool isGameActive { get; set; }

    // get player script
    PlayerController playerScript;

    // player animation
    Animator anim;

    // scene id
    private int badEndingId = 3;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        playerScript =
            GameObject.FindWithTag("Player").GetComponent<PlayerController>();

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
            SceneManager.LoadScene (badEndingId);
            anim.SetBool("damaged", true);
        }
    }
}
