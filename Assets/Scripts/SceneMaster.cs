using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMaster : MonoBehaviour
{
    [Header("SceneMaster's Animator")]
    public Animator Animator;

    [Header("Transform of Player Object")]
    public Transform PlayerTransform;

    [Header("Crosshair Game Object")]
    public GameObject Crosshair;

    [Header("Game Object of Keycard Image")]
    public GameObject keycardBlue;
    public GameObject keycardOrange;
    public GameObject keycardGreen;

    [Header("Game Object of Artifact")]
    public GameObject Artifact;

    [Header("Image Scriptable Object")]
    [SerializeField]
    private ImageSO ImageSO;

    [Header("Image Scriptable Object")]
    [SerializeField]
    private PositionSO PositionSO;

    private int levelToLoad;

    private void Start()
    {
        keycardBlue.SetActive(ImageSO.Activate[0]);
        keycardOrange.SetActive(ImageSO.Activate[1]);
        keycardGreen.SetActive(ImageSO.Activate[2]);
        Artifact.SetActive(ImageSO.Activate[3]);
    }

    private void Update()
    {
        Crosshair.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 0.3f));
    }

    public void FadeToLevel(int sceneIndex)
    {
        levelToLoad = sceneIndex;
        Animator.SetTrigger("Fade_Out");
    }

    public void OnFadeComplete()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PositionSO.Position["vents"] = PlayerTransform.position;
        }

        SceneManager.LoadScene(levelToLoad);
    }
}
