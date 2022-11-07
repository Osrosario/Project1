using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnHit : MonoBehaviour
{
    public string restartScene;
    public bool RestartToggle = false;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(restartScene);
            Cursor.lockState = CursorLockMode.None;
        }
          
    }

}
