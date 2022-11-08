using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    [Header("Lens Transform of This Object")]
    public Transform LensTransform;
    private bool isOn = true;

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            //Emit particle
        }
        else
        {
            //Do not emit particle
        }
        
    }

    public void SetState()
    {
        isOn = !isOn;
    }
}
