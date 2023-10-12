using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class PlayerMotor : MonoBehaviour
{
    [Header("Player Movement")]
    bool sprinting = false;
    public Image staminaBar;
    public float gravity = -9.8f;
    private bool isGrounded;
    private Vector3 playerVelocity;
    public float speed = 5f;
    public float stamina = 100;
    public float jumpHeight = 3f;
    bool crouching = false;
    float crouchTimer = 1;
    bool lerpCrouch = false;
    public AudioSource footStepSound; // Changed from SprintSound to footStepSound

    [Header("Player Component")]
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        stamina = Mathf.Clamp(stamina, 0, 100);
        staminaBar.fillAmount = Mathf.Clamp(stamina / 100, 0, 1f);

        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    public void FixedUpdate()
    {
        if(sprinting)
        {
            stamina -= 1;
        }
        else
        {
            stamina += 0.1f;
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);

        // Play footstep sound when moving
        if (input.magnitude > 0.1f && isGrounded)
        {
            if (!footStepSound.isPlaying)
                footStepSound.Play();
        }
        else
        {
            footStepSound.Stop();
        }
    }

    public void Jump()
    {
        if (isGrounded)
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
        if (sprinting && stamina >= 0)
        {
            speed = 8;
            
            footStepSound.pitch = 1.5f; // Adjust pitch for sprinting
        }
        else
        {
            speed = 5;
            
            footStepSound.pitch = 1.0f; // Reset pitch to normal when not sprinting
        }
    }
}
