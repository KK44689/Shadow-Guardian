using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBG : MonoBehaviour
{
    private Vector3 startPos;

    private float length;

    private float repeatWidth;

    [SerializeField]
    private float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // float temp = (transform.position.x * (1 - parallaxEffect));
        // float dist = (transform.position.x * parallaxEffect);
        // transform.position =
        //     new Vector3(startPos + dist,
        //         transform.position.y,
        //         transform.position.z);
        // if (temp > startPos + length)
        // {
        //     startPos += length;
        // }
        // else if (temp < startPos - length)
        // {
        //     startPos -= length;
        // }
        if (transform.position.x < startPos.x - length)
        {
            transform.position = startPos;
        }
    }
}
