using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Transform Orientation;
    public Rigidbody RB;
    
    [Header("Movement")]
    public float MoveSpeed;
    public float GroundDrag;

    [Header("Jumping")]
    public float JumpForce;
    public float JumpCoolDown;
    public float AirMultiplier;

    [Header("Ground Check")]
    public float PlayerHeight;
    public LayerMask WhatIsGround;
    
    private bool isGrounded;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private bool readyToJump;
    private bool canDoubleJump;
    private bool canMove;

    [Header("Image Scriptable Object")]
    [SerializeField]
    private PositionSO PositionSO;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.freezeRotation = true;
        
        readyToJump = true;
        canDoubleJump = true;
        canMove = true;

        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                transform.position = PositionSO.Position["vents"];
                break;
            case 1:
                transform.position = PositionSO.Position["roomOne"];
                break;
            case 2:
                transform.position = PositionSO.Position["roomTwo"];
                break;
            case 3:
                transform.position = PositionSO.Position["roomFour"];
                break;
        }
    }

    private void Update()
    {
        //Ground Check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.2f, WhatIsGround);

        if (canMove)
        {
            MyInput();
            SpeedControl();
        }
        

        //Apply Drag
        if (isGrounded)
        {
            RB.drag = GroundDrag;
            ResetJump();
        }
        else
        {
            RB.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && readyToJump && isGrounded)
        {
            readyToJump = false;
            Jump(JumpForce);
            //Invoke(nameof(ResetJump), JumpCoolDown);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump && !isGrounded)
        {
            canDoubleJump = false;
            Jump(JumpForce * 0.75f);
            //Invoke(nameof(ResetJump), JumpCoolDown);
        }
    }

    private void MovePlayer()
    {
        //Calculate Movement Direction
        moveDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;
        
        if (isGrounded)
        {
            RB.AddForce(moveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);
        }
        else
        {
            RB.AddForce(moveDirection.normalized * MoveSpeed * 10f * AirMultiplier, ForceMode.Force);
        }
    }

    public void DisableMovement()
    {
        canMove = !canMove;
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(RB.velocity.x, 0f, RB.velocity.z);

        //Limit Velocity
        if (flatVelocity.magnitude > MoveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * MoveSpeed;
            RB.velocity = new Vector3(limitedVelocity.x, RB.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump(float jumpForce)
    {
        //Reset Y Velocity
        RB.velocity = new Vector3(RB.velocity.x, 0f, RB.velocity.z);
        RB.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
        canDoubleJump = true;
    }
}
