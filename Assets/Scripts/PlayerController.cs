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

    //player damaged
    private bool isGirlDamaged = false;

    private float damagedDelays = 2f;

    public bool s_isGirlDamaged
    {
        get
        {
            return isGirlDamaged;
        }
        set
        {
            isGirlDamaged = value;
        }
    }

    // animation
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // set hp equal to max hp
        currentHp = maxHp;

        // connect slider to values
        hpBar.SetMaxHp (maxHp);
        hpBar.SetHp (maxHp);
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManager>();

        // check if the girl is damaged
        isGirlDamaged = false;

        // animation
        anim = GetComponent<Animator>();
    }

    IEnumerator GirlDamaged()
    {
        anim.SetBool("damaged", true);
        yield return new WaitForSeconds(damagedDelays);
        isGirlDamaged = false;
        anim.SetBool("damaged", false);
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
            isGirlDamaged = true;
            hpBar.SetHp (currentHp);
            StartCoroutine(GirlDamaged());
        }
    }
}
