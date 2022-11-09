using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Transform CamTransform;
    public CharacterController CC;
    public float MouseSensitivity;
    public float moveSpeed;
    public float gravity = -9.8f;
    public float jumpSpeed;
    public float verticalSpeed;

    private float camRotation;
    public bool canMove;

    [Header("Image Scriptable Object")]
    [SerializeField]
    private PositionSO PositionSO;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        canMove = true;

        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                transform.position = PositionSO.Position["vents"];
                jumpSpeed = 12f;
                break;
            case 1:
                transform.position = PositionSO.Position["roomOne"];
                jumpSpeed = 0;
                break;
            case 2:
                transform.position = PositionSO.Position["roomTwo"];
                jumpSpeed = 0;
                break;
            case 3:
                transform.position = PositionSO.Position["roomThree"];
                jumpSpeed = 15;
                break;
            case 4:
                transform.position = PositionSO.Position["roomFour"];
                jumpSpeed = 0;
                break;
        }
    }

    private void Update()
    {
        if (canMove)
        {
           Camera();
           Movement();
        }
    }

    public void DisableMovement()
    {
        canMove = !canMove;
    }

    private void Camera()
    {
        float mouseYInput = Input.GetAxis("Mouse Y") * MouseSensitivity;
        camRotation += -mouseYInput;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f);
        CamTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0f, 0f));

        float mouseXInput = Input.GetAxis("Mouse X") * MouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseXInput, 0f));
    }

    private void Movement()
    {
        Vector3 movement = Vector3.zero;

        float forwardMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; //Velocity for forward movement
        float sideMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; //Velocity for side movement

        movement += (transform.forward * forwardMovement) + (transform.right * sideMovement); //represents the direction of movement

        if (CC.isGrounded) //Has the object touched a collider?
        {
            verticalSpeed = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalSpeed = jumpSpeed;
            }
        }

        verticalSpeed += (gravity * Time.deltaTime);
        movement += (transform.up * verticalSpeed * Time.deltaTime);

        CC.Move(movement);
    }
}
