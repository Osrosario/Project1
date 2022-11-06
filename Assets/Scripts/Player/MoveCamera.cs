using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Camera Position from Player Object")]
    public Transform CamPosition;

    void Update()
    {
        transform.position = CamPosition.position;
    }
}
