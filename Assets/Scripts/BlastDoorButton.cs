using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastDoorButton : MonoBehaviour
{
    public AudioClip SwitchSound;

    [Header("Paired Buttons")]
    public GameObject ParallelButton1;
    public GameObject ParallelButton2;

    [Header("Paired Doors")]
    public GameObject DoorObject;

    [Header("Animation")]
    public Animator ButtonAnimator;
    public string AnimationName;
    
    [Header("Material")]
    public Material LightOff, LightOn;
    private bool isOn = false;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (!isOn)
        {
            gameObject.GetComponent<MeshRenderer>().material = LightOff;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = LightOn;
        }
    }

    public void SetState()
    {
        if (isOn != true)
        {
            isOn = true;
            DoorObject.GetComponent<DoorControl>().Unlock(isOn);
        }
        else
        {
            isOn = false;
            DoorObject.GetComponent<DoorControl>().Unlock(isOn);
        }
    }

    public void Press()
    {
        ButtonAnimator.Play(AnimationName);
        
        if (isOn != true)
        {
            audioSource.PlayOneShot(SwitchSound);
            isOn = true;
            ParallelButton1.GetComponent<BlastDoorButton>().SetState();
            ParallelButton2.GetComponent<BlastDoorButton>().SetState();
            DoorObject.GetComponent<DoorControl>().Unlock(isOn);
        }
    }
}
