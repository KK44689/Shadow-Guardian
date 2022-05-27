using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private int IntroSceneId = 2;

    public void StartGame()
    {
        SceneManager.LoadScene (IntroSceneId);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
