using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeColor : MonoBehaviour
{
    public Material LightOff, LightOn;
    private bool isOn = false;
    
    public void lightSwitch()
    {
        if(isOn != true)
        {
            gameObject.GetComponent<MeshRenderer>().material = LightOn;
            gameObject.tag = "Green";
            isOn = true;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = LightOff;
            gameObject.tag = "Red";
            isOn = false;
        }
    }

    public void SetState()
    {
        isOn = !isOn;
    }
}
