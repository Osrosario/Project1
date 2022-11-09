using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class KeyControl : MonoBehaviour
{
    public UnityEvent SwitchEvent;

    [Header("Game Objects")]
    public GameObject keyBlueObject;
    public GameObject keyGreenObject;
    public GameObject keyOrangeObject;
    public GameObject DoorObject;

    [Header("Image Game Object")]
    public GameObject keyBlueImage;
    public GameObject keyGreenImage;
    public GameObject keyOrangeImage;
   
    public PlayerStats Inventory;
    public ImageSO ImageSO;
    private List<string> keyCards;
    public int count = 0;
   
    public void KeyUnlock()
    {
        keyCards = Inventory.GetInventory();
        
        for(int i = 0; i < keyCards.Count; i++) 
        {
            if (keyCards[i] == "blueKeycard")
            {
                keyBlueObject.SetActive(true);
                keyCards.Remove(keyCards[i]);
                keyBlueImage.SetActive(false);
                ImageSO.Activate[0] = false;
                count += 1;
            }
            else if (keyCards[i] == "orangeKeycard")
            {
                keyOrangeObject.SetActive(true);
                keyCards.Remove(keyCards[i]);
                keyOrangeImage.SetActive(false);
                ImageSO.Activate[1] = false;
                count += 1;
            }
            else if (keyCards[i] == "greenKeycard")
            {
                keyGreenObject.SetActive(true);
                keyCards.Remove(keyCards[i]);
                keyGreenImage.SetActive(false);
                ImageSO.Activate[2] = false;
                count += 1;
            }
        }

        if (count == 3)
        {
            DoorObject.GetComponent<DoorControl>().Unlock(true);
        }
        
    }
}
