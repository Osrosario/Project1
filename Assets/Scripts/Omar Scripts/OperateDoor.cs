using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Uses raycast from player object to call operate() to open a door. 
 * 
 * StartCoroutine(doorOperating) function allows the animation to play 
 * and prevents the player from repeatedly initiating the opening/closing 
 * door animation.
 */

public class OperateDoor : MonoBehaviour
{
    //Insert object pivot
    public Animator doorAnimator;

    //Determines if the door is closed or open
    private string doorState = "closed";
    
    //Determines if the door is in the process of opening/closing
    private bool isMoving = false;

    //Function to call from raycast.
    public void operate()
    {
        if (doorState == "closed" && !isMoving)
        {
            doorAnimator.Play("OpenDoor");
            isMoving = true;
            StartCoroutine(doorOperating());
        }
        else if (doorState == "open" && !isMoving)
        {
            doorAnimator.Play("CloseDoor");
            isMoving = true;
            StartCoroutine(doorOperating());
        }
    }

    IEnumerator doorOperating()
    {
        yield return new WaitForSeconds(1);

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
