

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public CharacterController controller;
    public float moveSpeed = 8f;
    float xAxis = 0f;
    float zAxis = 0f;
    public Vector3 move;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;
    public bool isGrounded;
    public Vector3 velocity;

    public float runSpeed = 20f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded) {
            xAxis = Input.GetAxis("Horizontal");
            zAxis = Input.GetAxis("Vertical");
        }
        move = transform.right * xAxis + transform.forward * zAxis;
       
        if(Input.GetButton("Fire3")) {
            controller.Move(move * moveSpeed * Time.deltaTime * runSpeed);
        } else {
            controller.Move(move * moveSpeed * Time.deltaTime);
        }
                     
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }


}
