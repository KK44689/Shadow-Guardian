using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToScrrenSize : MonoBehaviour
{
    private float width;

    [SerializeField]
    private bool scaleBothWidthHeight;

    void Start()
    {
        width =
            Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.scaleBothWidthHeight)
        {
            ScaleWidthAndHeight();
        }
        else
        {
            ScaleOnlyWidth();
        }
    }

    void ScaleWidthAndHeight()
    {
        transform.localScale =
            new Vector3(width / 9.0f, width / 9.0f, width / 9.0f);
    }

    void ScaleOnlyWidth()
    {
        transform.localScale =
            new Vector3(width / 9.0f,
                transform.localScale.y,
                transform.localScale.z);
    }
}
