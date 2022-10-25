using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTwoDoor : MonoBehaviour
{

    public Animator[] doorAnimatorA, doorAnimatorB = new Animator[0]; 

    public Material[] newMaterial = new Material[1];
    public MeshRenderer meshRenderer;
    public string[] strA, strB = new string[0];

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
            doorAnimatorA[0].Play(strA[0]);
            doorAnimatorB[0].Play(strB[0]);
            isMoving = true;
            meshRenderer.material = newMaterial[0];
            StartCoroutine(doorOperating());
        }
        else if (doorState == "open" && !isMoving)
        {
            doorAnimatorA[0].Play(strA[1]);
            doorAnimatorB[0
                ].Play(strB[1]);
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
