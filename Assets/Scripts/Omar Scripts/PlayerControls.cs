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
        //Initialize spawn point.
        spawnPoint = transform.position;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Camera();
        Movement();
        

        if (Input.GetMouseButton(0))
        {
            playerButton();
        }

        //Respawn condition if player falls off the map.
        if (transform.position.y < -20)
        {
            transform.position = spawnPoint;
        }
    }
    //Controls Toggling button in the maze's allowing the doors to open


    //Controls the movement of the camera using mouse movement.
    private void Camera()
    {
        float mouseYInput = Input.GetAxis("Mouse Y") * MouseSensitivity;
        camRotation += -mouseYInput;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f);
        CamTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0f, 0f));

        float mouseXInput = Input.GetAxis("Mouse X") * MouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseXInput, 0f));
    }

    //Controls the movement of the player object using WASD or arrow keys.
    //Allows the player to double jump.
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
    private void playerButton()
    {
        RaycastHit hit;

        if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit))
        {
            //Debug.Log(hit.collider.gameObject.name);
            //SwitchButton();
            Button pressButtonHit = hit.collider.GetComponent<Button>();
            ButtonUp pressUpHit = hit.collider.GetComponent<ButtonUp>();
            //maze 2 buttons
            ButtonUpM2 pressUpHitM2 = hit.collider.GetComponent<ButtonUpM2>();
            ButtonUp1 pressUpHit1 = hit.collider.GetComponent<ButtonUp1>();
            ButtonUp2 pressUpHit2 = hit.collider.GetComponent<ButtonUp2>();
            ButtonUp3 pressUpHit3 = hit.collider.GetComponent<ButtonUp3>();
            ButtonRotate pressRotateHit = hit.collider.GetComponent<ButtonRotate>();
            //Button pressButton = hit.collider.GetComponent<Button>();
            if (pressButtonHit != null)
            {
                pressButtonHit.operate();
            }
            if (pressUpHit != null)
            {
                pressUpHit.operate();
            }
            //maze 2 buttons
            if (pressUpHitM2 != null)
            {
                pressUpHitM2.operate();
            }
            if (pressUpHit1 != null)
            {
                pressUpHit1.operate();
            }
            if (pressUpHit2 != null)
            {
                pressUpHit2.operate();
            }
            if (pressUpHit3 != null)
            {
                pressUpHit3.operate();
            }
            if (pressRotateHit != null)
            {
                pressRotateHit.operate();
            }
        }
    }
}
