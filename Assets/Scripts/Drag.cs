using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public float Speed;

    public void DragObject(Transform player)
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
    }
}
