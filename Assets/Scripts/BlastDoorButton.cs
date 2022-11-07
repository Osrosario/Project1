using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlastDoorButton : MonoBehaviour
{
    public UnityEvent SwitchEvent;
    public AudioClip SwitchSound;
    public Animator ButtonAnimator;
    public string AnimationName;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnUse()
    {
        ButtonAnimator.Play(AnimationName);
        audioSource.PlayOneShot(SwitchSound);
        SwitchEvent.Invoke();
    }
}
