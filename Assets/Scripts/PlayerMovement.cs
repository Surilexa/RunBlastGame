using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 02f;
    public float sprintMultiplier = 1f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    

    bool isGrounded;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * sprintMultiplier;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprintMultiplier = 1.5f;
           // Debug.LogError("down");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprintMultiplier = 1f;
           // Debug.LogError("up");
        }



        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime); 
    }
}
