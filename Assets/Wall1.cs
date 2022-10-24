using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall1 : MonoBehaviour
{
    //Insert object pivot
    public Animator doorAnimatorA;
    public Animator doorAnimatorB;

    //Determines if the door is closed or open
    private string doorState = "closed";

    //Determines if the door is in the process of opening/closing
    private bool isMoving = false;

    //Function to call from raycast.
    public void operate()
    {
        if (doorState == "closed" && !isMoving)
        {
            doorAnimatorA.Play("MW1_Move_Right");
            doorAnimatorB.Play("MW2_Move_Right");
            isMoving = true;
            StartCoroutine(doorOperating());
        }
        else if (doorState == "open" && !isMoving)
        {
            doorAnimatorA.Play("MW1_Move_Left");
            doorAnimatorB.Play("MW2_Move_Left");
            isMoving = true;
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
