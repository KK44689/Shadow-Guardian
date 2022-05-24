using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("damage player");
            Destroy (gameObject);
        }
        if (other.gameObject.CompareTag("Spirit"))
        {
            Debug.Log("spirit protect");
            Destroy (gameObject);
        }
    }
}
