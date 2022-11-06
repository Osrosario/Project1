using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform Orientation;
    public float SensitivityX;
    public float SensitivityY;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Get Mouse Input
        float mouseXInput = Input.GetAxisRaw("Mouse X") * SensitivityX * Time.fixedDeltaTime;
        float mouseYInput = Input.GetAxisRaw("Mouse Y") * SensitivityY * Time.fixedDeltaTime;

        yRotation += mouseXInput;
        
        xRotation -= mouseYInput;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotate Camera and Player Orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
