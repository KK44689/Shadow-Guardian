using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // player hp
    private int maxHp = 10;

    // game Manager
    GameManager gameManager;

    // hp Bar
    public HpBar hpBar;

    public int s_maxHp
    {
        get
        {
            return maxHp;
        }
        set
        {
            if (value < 0)
            {
                Debug.LogError("max Hp can't below zero!");
            }
            else
            {
                maxHp = value;
            }
        }
    }

    private int currentHp = 10;

    public int s_currentHp
    {
        get
        {
            return currentHp;
        }
        set
        {
            if (value < 0)
            {
                Debug.LogError("Hp can't below zero!");
            }
            else
            {
                currentHp = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        hpBar.SetMaxHp (maxHp);
        hpBar.SetHp (maxHp);
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameManager.isGameActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            currentHp--;
            hpBar.SetHp (currentHp);
        }
    }
}
