using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObjectToScreen : MonoBehaviour
{
    private float width;

    private void Start()
    {
        width =
            Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale =
            new Vector3(width / 9.0f,
                transform.localScale.y,
                transform.localScale.z);
    }
}
