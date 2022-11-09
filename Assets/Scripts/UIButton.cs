using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [Header("Button_Check Event: Button_Check --> LoadScene")]
    [Header("Button_X Event: Vent --> HidePop")]
    public GameObject SceneMaster;
    
    private int sceneIndex;
    private GameObject ventObject;
    
    public void LoadScene()
    {
        SceneMaster.GetComponent<SceneMaster>().FadeToLevel(sceneIndex);
    }
   
    public void LoadThisScene(int index)
    {
        sceneIndex = index;
    }

    public void SendVentObject(GameObject vent)
    {
        ventObject = vent;
    }
    
    public void CloseThisPopUp()
    {
        ventObject.GetComponent<EnterRoom>().HidePopUp();
    }
}
