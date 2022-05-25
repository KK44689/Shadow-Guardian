using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // game Manager
    GameManager gameManager;

    // player script
    PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManager>();
        playerScript =
            GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive && !playerScript.s_isGirlDamaged)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
