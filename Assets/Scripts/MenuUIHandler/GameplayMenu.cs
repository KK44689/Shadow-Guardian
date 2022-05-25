using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenu : MonoBehaviour
{
    // pause menu
    public GameObject PauseMenu;

    public GameObject PauseButton;

    // scene id
    private int menuSceneId = 0;

    void Start()
    {
        PauseMenu.SetActive(false);
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void BacktoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
