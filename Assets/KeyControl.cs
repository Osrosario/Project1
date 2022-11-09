using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class KeyControl : MonoBehaviour
{
    public UnityEvent SwitchEvent;
    public GameObject keyBlue, keyGreen, keyOrange;
    public PlayerStats Inventory;
    public ImageSO Image;
    private List<string> keyCards;
    private List<bool> Items;
    public int count = 0;
    

    // Update is called once per frame
    public void KeyUnlock()
    {
        //keyCards = Inventory.GetInventory();


        for(int i = 0; i < keyCards.Count; i++) 
        {
            if (keyCards[i] == "blueKeycard")
            {
                keyBlue.SetActive(true);
                keyCards.Remove(keyCards[i]);
                count += 1;
            }
            else if (keyCards[i] == "greenKeycard")
            {
                keyGreen.SetActive(true);
                keyCards.Remove(keyCards[i]);
                count += 1;
            }
            else if (keyCards[i] == "orangeKeycard")
            {
                keyOrange.SetActive(true);
                keyCards.Remove(keyCards[i]);
                count += 1;
            }
        }


        if (count == 3)
        {
            SwitchEvent.Invoke();
        }
        
    }
}
