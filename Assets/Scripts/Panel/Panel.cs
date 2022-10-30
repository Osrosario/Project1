using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject PanelObject;
    public Vector3 targetPosition;
    public float smoothTime = 0.5f;
    public float speed = 10;

    private Vector3 velocity;
    private float screwsOut;
    private bool areScrewsOut = false;
    private bool canRemoveVent = false;

    private void Update()
    {
        if (canRemoveVent)
        {
            PanelObject.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);
        }
    }


    public void ScrewsOut(float number)
    {
        screwsOut += number;

        if (screwsOut == 4)
        {
            areScrewsOut = true;
        }
    }

    public void Move()
    {
        if (areScrewsOut)
        {
            canRemoveVent = true;
        }
    }
}   

