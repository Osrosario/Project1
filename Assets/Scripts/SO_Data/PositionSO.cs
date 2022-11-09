using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PositionSO : ScriptableObject
{
    [SerializeField]
    private Dictionary<string, Vector3> position = new Dictionary<string, Vector3> 
    {
        { "vents", new Vector3(-10.75f, 17f, 0f) },
        { "roomOne", new Vector3(0f, 1.7f, -4.25f) },
        { "roomTwo", new Vector3(6f, 1.5f, -5.2f) },
        { "roomThree", new Vector3(0.75f, 1f, 3f) },
        { "roomFour", new Vector3(-1.875f, 1.5f, -7.125f) }
    };

    public Dictionary<string, Vector3> Position
    {
        get { return position; }
        set { position = value; }
    }
}
