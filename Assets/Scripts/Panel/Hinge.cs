using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hinge : MonoBehaviour
{
    public Transform ObjectPivot;
    public Vector3 TargetDegree;
    public float Speed;

    public bool isOpen = false;

    private void Update()
    {
        if (isOpen)
        {
            ObjectPivot.eulerAngles = Vector3.Lerp(ObjectPivot.eulerAngles, TargetDegree, Speed * Time.deltaTime);
        }
    }

    public void Open()
    {
        isOpen = true;
    }
}
