using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeColor : MonoBehaviour
{
    public Material LightOff, LightOn;
    private bool isOn = false;
    
    public void Update()
    {
        if (!isOn)
        {
            gameObject.GetComponent<MeshRenderer>().material = LightOff;
            gameObject.tag = "Red";
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = LightOn;
            gameObject.tag = "Green";
        }
    }

    public void SetState()
    {
        isOn = !isOn;
    }

    public void ResetState()
    {
        isOn = false;
    }
}
