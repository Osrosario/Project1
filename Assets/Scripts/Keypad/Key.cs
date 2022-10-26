using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public UnityEvent KeyPressed;

    public void PressKey()
    {
        KeyPressed.Invoke();
    }
}
