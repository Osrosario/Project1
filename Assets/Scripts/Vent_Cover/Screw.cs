using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Screw : MonoBehaviour
{
    public UnityEvent ScrewOut;

    public void Remove()
    {
        ScrewOut.Invoke();
        Destroy(gameObject);
    }
}
