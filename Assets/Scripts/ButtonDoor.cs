using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonDoor : MonoBehaviour
{
    public UnityEvent SwitchEvent;
    // Update is called once per frame
    void Update()
    {

    }
    public void OnUse()
    {
        SwitchEvent.Invoke();
    }
}
