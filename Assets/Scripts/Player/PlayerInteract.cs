using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    public Transform CamTransform;
    public float rayCastDistance;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Keypad();
            Store();
            SwitchButton();
            PlaceKeys();
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Keypad()
    {
        RaycastHit hit;

        if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit, rayCastDistance))
        {
            Key hitKey = hit.collider.GetComponent<Key>();

            if (hitKey != null)
            {
                hitKey.PressKey();
            }
        }
    }

    private void Store()
    {
        RaycastHit hit;

        if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit, rayCastDistance))
        {
            Debug.DrawLine(CamTransform.position, hit.point, Color.green, 5f);

            PickUp hitObject = hit.collider.gameObject.GetComponent<PickUp>();

            if (hitObject != null)
            {
                hitObject.Store();
            }
        }
    }

    private void SwitchButton()
    {
        RaycastHit hit;

        if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit, rayCastDistance))
        {
            BlastDoorButton hitButton = hit.collider.gameObject.GetComponent<BlastDoorButton>();
            
            if (hitButton != null)
            {
                hitButton.Press();
            }
        }
    }

    private void PlaceKeys()
    {
        RaycastHit hit;

        if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit, rayCastDistance))
        {
            KeyControl hitButton = hit.collider.gameObject.GetComponent<KeyControl>();
            
            if (hitButton != null)
            {
                hitButton.KeyUnlock();
            }
        }
    }
}

