using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    private float screwsOut;
    private bool canRemoveVent = false;
    
    public void ScrewsOut(float number)
    {
        screwsOut += number;

        if (screwsOut == 4)
        {
            canRemoveVent = true;
        }
    }

    public void RemoveVent()
    {
        if (canRemoveVent)
        {
            Debug.Log("VENT REMOVED");
        }
    }
}   

