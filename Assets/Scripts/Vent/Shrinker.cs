using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinker : MonoBehaviour
{
    
    private void Update()
    {
        transform.localScale = new Vector3(0, Sin(), 0);
    }

    private float Sin()
    {
        return Mathf.Sin(Time.time * 5);
    }
}
