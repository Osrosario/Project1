using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ImageSO : ScriptableObject
{
    [SerializeField]
    private List<bool> isActive;

    public List<bool> Activate
    {
        get { return isActive; }
        set { isActive = value; }
    }
}
