using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f, 1f)]
    [SerializeField]
    private float scrollSpeed = 0.5f;

    private float offset;

    private Material mat;

    // player script
    PlayerController playerScript;

    //gamemanager
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        playerScript =
            GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive && !playerScript.s_isGirlDamaged)
        {
            offset += (Time.deltaTime * scrollSpeed) / 10f;
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
