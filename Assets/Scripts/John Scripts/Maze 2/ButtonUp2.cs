using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUp2 : MonoBehaviour
{
    
    public Animator doorAnimatorA;

    public Material[] newMaterial = new Material[1];
    public MeshRenderer meshRenderer;

    //Determines if the door is closed or open
    private string doorState = "closed";

    //Determines if the door is in the process of opening/closing
    private bool isMoving = false;

    //Function to call from raycast.
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public void operate()
    {
        if (doorState == "closed" && !isMoving)
        {
            doorAnimatorA.Play("MW2_Move_Down");
            isMoving = true;
            meshRenderer.material = newMaterial[0];
            StartCoroutine(doorOperating());
        }
        else if (doorState == "open" && !isMoving)
        {
            doorAnimatorA.Play("MW2_Move_Up");
            isMoving = true;
            meshRenderer.material = newMaterial[0];
            StartCoroutine(doorOperating());
        }
    }

    IEnumerator doorOperating()
    {
        yield return new WaitForSeconds(2);

        if (doorState == "closed" && isMoving)
        {
            doorState = "open";
            isMoving = false;
        }
        else if (doorState == "open" && isMoving)
        {
            doorState = "closed";
            isMoving = false;
        }
    }
}
