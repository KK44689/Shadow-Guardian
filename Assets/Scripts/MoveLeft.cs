using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // game Manager
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
