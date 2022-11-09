using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ExitGame : MonoBehaviour
{
    [Header("First Event: Player --> DisableMovement")]
    //[Header("Second Event: Button_Check --> LoadThisScene")]
    [Header("Second Event: Button_x --> SendVentObject")]

    public UnityEvent EnterEvent;

    public GameObject SceneMaster;
    public GameObject PlayerObject;
    public GameObject ButtonCheck;
    public GameObject ButtonX;
    public TMP_Text PopUpText;
    public string trueMessage;
    public string falseMessage;

    private bool isPromptShowing = false;
    private bool isPopUpShowing = false;
    private Animator sceneMasterAnimator;
    private List<string> checkList;
    private UIButton buttonCheck;
    private UIButton buttonX;

    private void Start()
    {
        sceneMasterAnimator = SceneMaster.GetComponent<Animator>();
        checkList = PlayerObject.GetComponent<PlayerStats>().GetInventory();
        buttonCheck = ButtonCheck.GetComponent<UIButton>();
        buttonX = ButtonX.GetComponent<UIButton>();
    }


    private void Update()
    {
        if (isPromptShowing)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (checkList.Contains("artifact") != true)
                {
                    PopUpText.text = falseMessage;
                }
                else
                {
                    PopUpText.text = trueMessage;
                }

                if (!isPopUpShowing)
                {
                    sceneMasterAnimator.Play("Show_PopUp");
                    Cursor.lockState = CursorLockMode.None;
                    isPopUpShowing = true;
                    EnterEvent.Invoke();
                }
                else
                {
                    sceneMasterAnimator.Play("Hide_PopUp");
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
            sceneMasterAnimator.Play("Show_Prompt");
            isPromptShowing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sceneMasterAnimator.Play("Hide_Prompt");
            isPromptShowing = false;
        }
    }
}
