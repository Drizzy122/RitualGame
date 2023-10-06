using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMotor : MonoBehaviour
{
    [Header("Player Movement")]
    bool sprinting = false;
    public float gravity = -9.8f; //add gravity 
    private bool isGrounded; //Check if the player is grounded or not
    private Vector3 playerVelocity;
    public float speed = 5f; //Set tge speed of the player
    public float jumpHeight = 3f;
    bool crouching = false;
    float crouchTimer = 1;
    bool lerpCrouch = false;
    [Header("Player Component")]
    private CharacterController controller;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        isGrounded = controller.isGrounded;
        if(lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if(p>1)

            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }
    public void ProcessMove(Vector2 input)
    {
        // Calculate movement direction
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0f;
        lerpCrouch = true;
    }
    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
            speed = 8;
        else
            speed = 5;
    }
}