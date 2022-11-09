using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public List<string> Inventory;

    [Header("Image Scriptable Object")]
    [SerializeField]
    private InventorySO InventorySO;

    private void Start()
    {
        Inventory = InventorySO.KeyList;
    }

    public void AddToInventory(string theObject)
    {
        Inventory.Add(theObject);
        InventorySO.KeyList = Inventory;
    }
    public void EmptyInventory(){
        InventorySO.KeyList.Clear();        
    }
    public List<string> GetInventory(){
        return Inventory;
    }
}
