using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public Animator BF_Animator;

    private int levelToLoad;

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            FadeToLevel(0);
        }
        */
    }

    public void FadeToLevel(int sceneIndex)
    {
        levelToLoad = sceneIndex;
        BF_Animator.SetTrigger("Fade_Out");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
