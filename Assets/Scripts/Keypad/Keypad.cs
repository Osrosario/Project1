using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Keypad : MonoBehaviour
{   
    public AudioClip BeepSound, AccessGrantedSound, DeniedSound;
    public TextMeshPro DisplayText;
    public string Password;

    private AudioSource audioSource;
    private string pressedKeys = "";
    private string deniedText = "ACCESS DENIED";
    private string accessGrantedText = "ACCESS GRANTED";
    private bool isUnlocked = false;
    private bool canType = true;

    public UnityEvent UnlockDoor;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isUnlocked)
        {
            DisplayText.text = accessGrantedText;
        }
        else
        {
            DisplayText.text = pressedKeys;
        }
    }

    public void RecordPressedKey(string input)
    {
        audioSource.PlayOneShot(BeepSound);
        
        if (canType)
        {
            if (input == "Clear")
            {
                pressedKeys = "";
            }
            else
            {
                pressedKeys += input;

                if (pressedKeys.Length == 4)
                {
                    if (pressedKeys == Password)
                    {
                        canType = false;
                        pressedKeys = accessGrantedText;
                        audioSource.PlayOneShot(AccessGrantedSound);
                        isUnlocked = true;
                        UnlockDoor.Invoke();
                    }
                    else
                    {
                        canType = false;
                        pressedKeys = deniedText;
                        audioSource.PlayOneShot(DeniedSound);
                        StartCoroutine(DisplayMessage());
                    }
                }
            }
        }
        
        
        
    }

    private IEnumerator DisplayMessage()
    {
        yield return new WaitForSeconds(2);
        pressedKeys = "";
        canType = true;
    }
}
