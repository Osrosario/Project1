using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public GameObject DoorObject;
    public AudioClip OpenDoorSound;
    public AudioClip CloseDoorSound;
    public Vector3 originalPosition;
    public Vector3 targetPosition;
    public float smoothTime = 0.5f;
    public float speed = 10;

    private AudioSource audioSource;
    private Vector3 velocity;
    public bool isUnlocked = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isUnlocked)
        {
            DoorObject.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);
        }    
        else
        {
            DoorObject.transform.position = Vector3.SmoothDamp(transform.position, originalPosition, ref velocity, smoothTime, speed);
        }
    }

    public void Unlock()
    {
        isUnlocked = !isUnlocked;

        if (isUnlocked)
        {
            audioSource.PlayOneShot(CloseDoorSound);
        }
        else
        {
            audioSource.PlayOneShot(OpenDoorSound);
        }
    }
}
