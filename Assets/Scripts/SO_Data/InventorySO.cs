using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    [SerializeField]
    private List<string> keyList;

    public List<string> KeyList
    {
        get { return keyList; }
        set { keyList = value; }
    }
}
