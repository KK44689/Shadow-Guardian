using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour
{
    private int mainSceneId = 1;

    private int mainMenuSceneId = 0;

    public void Restart()
    {
        SceneManager.LoadScene (mainSceneId);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene (mainMenuSceneId);
    }
}
