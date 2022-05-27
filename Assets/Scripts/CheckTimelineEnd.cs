using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CheckTimelineEnd : MonoBehaviour
{
    public PlayableDirector director;

    private int mainSceneId = 1;

    void OnEnable()
    {
        director.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
        {
            SceneManager.LoadScene (mainSceneId);
        }
    }

    void OnDisable()
    {
        director.stopped -= OnPlayableDirectorStopped;
    }
}
