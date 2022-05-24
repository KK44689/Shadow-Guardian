using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObstacle : MonoBehaviour
{
    GameObject Player;

    Rigidbody2D rb;

    [SerializeField]
    private float obstacleForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDistant = Player.transform.position - transform.position;
        playerDistant.Normalize();
        rb.AddForce(playerDistant * obstacleForce, ForceMode2D.Impulse);
    }
}
