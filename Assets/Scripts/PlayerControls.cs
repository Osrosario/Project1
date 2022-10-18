using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public Transform CamTransform;
    public CharacterController CC;
    public float MouseSensitivity;
    public float moveSpeed;
    public float gravity;
    public float jumpSpeed;
    public float verticalSpeed;

    private Vector3 spawnPoint;
    private bool canDoubleJump = false;
    private float camRotation;

    void Start()
    {
        //Initialize spawn point
        spawnPoint = transform.position;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Camera();
        Movement();

        if (Input.GetMouseButton(0))
        {
            //Empty conditional statement for future raycast functionality
        }

        //Respawn condition if player falls off the map
        if (transform.position.y < -20)
        {
            transform.position = spawnPoint;
        }
    }

    //Controls the movement of the camera using mouse movement
    private void Camera()
    {
        float mouseYInput = Input.GetAxis("Mouse Y") * MouseSensitivity;
        camRotation += -mouseYInput;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f);
        CamTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0f, 0f));

        float mouseXInput = Input.GetAxis("Mouse X") * MouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseXInput, 0f));
    }

    //Controls the movement of the player object using WASD or arrow keys
    private void Movement()
    {
        Vector3 movement = Vector3.zero;

        float forwardMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; 
        float sideMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

        if (CC.isGrounded)
        {
            canDoubleJump = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalSpeed = jumpSpeed;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                verticalSpeed = jumpSpeed * 0.75f;
                canDoubleJump = false;
            }
        }

        verticalSpeed += (gravity * Time.deltaTime);
        movement += (transform.up * verticalSpeed * Time.deltaTime);

        CC.Move(movement);
    }
}
