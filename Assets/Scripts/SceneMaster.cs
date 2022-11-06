using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMaster : MonoBehaviour
{
    [Header("SceneMaster's Animator")]
    public Animator Animator;

    [Header("Crosshair Game Object")]
    public GameObject Crosshair;

    [Header("Game Object of Keycard Image")]
    public GameObject keycardBlue;
    public GameObject keycardOrange;
    public GameObject keycardGreen;

    [Header("Image Scriptable Object")]
    [SerializeField]
    private ImageSO ImageSO;

    private int levelToLoad;

    private void Start()
    {
        keycardBlue.SetActive(ImageSO.Activate[0]);
        keycardOrange.SetActive(ImageSO.Activate[1]);
        keycardGreen.SetActive(ImageSO.Activate[2]);
    }

    private void Update()
    {
        Crosshair.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 0.3f));
    }

    public void FadeToLevel(int sceneIndex)
    {
        levelToLoad = sceneIndex;
        Animator.Play("Fade_Out");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
