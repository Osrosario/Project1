using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform ObjectToRotate;
    public Vector3 Rotation;
    public float Speed;

    void Update()
    {
        ObjectToRotate.Rotate(Rotation * Speed * Time.deltaTime);
    }
}
