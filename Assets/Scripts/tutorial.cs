using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    public GameObject[] tutorials;

    private int index = 1;

    // scene id
    private int mainSceneId = 1;

    public GameObject clickText;

    public GameObject tapText;

    private void Start()
    {
        tutorials[0].SetActive(true);
        CheckDevice();
    }

    public string platform { get; set; }

    private void Update()
    {
        if (platform == "Desktop")
        {
            clickText.SetActive(true);
            tapText.SetActive(false);
        }
        if (platform == "Handheld")
        {
            clickText.SetActive(false);
            tapText.SetActive(true);
        }
        if ((Input.GetMouseButtonDown(0)) && (index < tutorials.Length))
        {
            tutorials[0].SetActive(false);
            tutorials[index - 1].SetActive(false);
            tutorials[index].SetActive(true);
            index++;
        }
        else if ((Input.GetMouseButtonDown(0)) && index >= tutorials.Length)
        {
            SceneManager.LoadScene (mainSceneId);
        }
    }

    private void CheckDevice()
    {
        //Check if the device running this is a desktop
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            platform = "Desktop";
        }

        //Check if the device running this is a handheld
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            platform = "Handheld";
        }
        else
        {
            platform = SystemInfo.deviceType.ToString();
        }
    }
}
