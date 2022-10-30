using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hinge : MonoBehaviour
{
    bool pointAtA = false;
    float speed = 6f;

    float angleA = 0f;
    float angleB = 90f;

    Quaternion a;
    Quaternion b;

    private bool isOpen = false;

    void Awake()
    {
        a = Quaternion.AngleAxis(angleA, Vector3.forward);
        b = Quaternion.AngleAxis(angleB, Vector3.forward);
    }

    void Update()
    {
        if (isOpen)
            pointAtA = !pointAtA;

        Quaternion target = pointAtA ? a : b;
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * speed);
    }

    public void Open()
    {
        isOpen = true;
    }
}
