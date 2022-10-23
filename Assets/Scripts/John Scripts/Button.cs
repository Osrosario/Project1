using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool ButtonToggle = false;
    public GameObject Floor;
    public Material[] newMaterial = new Material[1];
    public MeshRenderer meshRenderer;


    void Start()
    { 
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private string buttonMessage = "Toggled!";
   
    public void OnUse()
    {
        Debug.Log("button" + buttonMessage);
        ButtonToggle = true;
        
        if (ButtonToggle != true)
        {
            Floor.SetActive(false);
            meshRenderer.material = newMaterial[0];
        }
        else
        {
            Floor.SetActive(true);
            meshRenderer.material = newMaterial[1];
        }
    }
}
