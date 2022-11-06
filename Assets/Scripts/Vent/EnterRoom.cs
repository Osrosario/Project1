using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class EnterRoom : MonoBehaviour
{
    [Header("First Event: Player --> DisableMovement")]
    [Header("Second Event: Button_Check --> LoadThisScene")]

    public UnityEvent EnterEvent;
    public Animator SceneMasterAnimator;
    public TMP_Text PopUpText;
    public string Message;

    private bool isPromptShowing = false;
    private bool isPopUpShowing = false;

    private void Update()
    {
        if (isPromptShowing)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PopUpText.text = Message;

                if (!isPopUpShowing)
                {
                    SceneMasterAnimator.Play("Show_PopUp");
                    Cursor.lockState = CursorLockMode.None;
                    isPopUpShowing = true;
                    EnterEvent.Invoke();
                }
                else
                {
                    SceneMasterAnimator.Play("Hide_PopUp");
                    Cursor.lockState = CursorLockMode.Locked;
                    isPopUpShowing = false;
                    EnterEvent.Invoke();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneMasterAnimator.Play("Show_Prompt");
            isPromptShowing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneMasterAnimator.Play("Hide_Prompt");
            isPromptShowing = false;
        }
    }

    public void HidePopUp()
    {
        Debug.Log("HIDE");
        SceneMasterAnimator.Play("Hide_PopUp");
        Cursor.lockState = CursorLockMode.Locked;
        isPopUpShowing = false;
        EnterEvent.Invoke();
    }
}
