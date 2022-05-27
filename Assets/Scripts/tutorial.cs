using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    public GameObject[] tutorials;

    private int index = 1;

    private void Start()
    {
        tutorials[0].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && index < tutorials.Length)
        {
            tutorials[0].SetActive(false);

            tutorials[index - 1].SetActive(false);
            tutorials[index].SetActive(true);
            index++;
        }
        if (index >= tutorials.Length)
        {
            SceneManager.LoadScene(1);
        }
    }
}
