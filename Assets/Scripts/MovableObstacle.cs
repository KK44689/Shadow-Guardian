using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObstacle : MonoBehaviour
{
    GameObject Player;

    Rigidbody2D rb;

    [SerializeField]
    private float obstacleForce = 1f;

    [SerializeField]
    private float obstacleReflectForce = 10f;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if obstacles damage player
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player damaged");
            Destroy (gameObject);
        }

        // check if spirit protect the player
        if (other.gameObject.CompareTag("Spirit"))
        {
            Debug.Log("spirit protect");
            Vector3 reflectDistant =
                (transform.position - Player.transform.position);
            reflectDistant.Normalize();
            rb
                .AddForce(reflectDistant * obstacleReflectForce,
                ForceMode2D.Impulse);
            // Destroy (gameObject);
        }
    }
}
