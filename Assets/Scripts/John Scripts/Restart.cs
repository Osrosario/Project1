using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string restartScene;
    public bool RestartToggle;

    private string restartMessage = "Toggled!";
    public void RestartHit()
    {
        Debug.Log("reset" + restartMessage);
        RestartToggle = true;
        if (RestartToggle == true)
        {
            Debug.Log("work");
            SceneManager.LoadScene(restartScene);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Debug.Log("no work");
        }
    }
}
