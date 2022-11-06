using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    public UnityEvent InventoryStore;

    [Header("Event: PlayerObject --> AddToInventory")]
    public GameObject ImageOfObject;
    public int IndexOfKeycard;

    [Header("Image Scriptable Object")]
    [SerializeField]
    private ImageSO ImageSO;

    public void Store()
    {
        Destroy(gameObject);
        bool isActive = ImageSO.Activate[IndexOfKeycard] = true;
        ImageOfObject.SetActive(isActive);
        InventoryStore.Invoke();
    }
}
