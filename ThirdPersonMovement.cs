using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;//the motor that drives the player
    //public Animator animator;

    public Camera ThirdPersonCamera;
    public Camera FallingCamera;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float Distance;

    public Transform cameraChange;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    //The hash (#) character in front of the if and endif indicates that these statements are “directives”, and are handled during the compilation process, rather than at runtime.

    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    public void fallingCamera()
    {
        ThirdPersonCamera.enabled = false;
        FallingCamera.enabled = true;
    }

    public void thirdPersonCamera()
    {
        ThirdPersonCamera.enabled = true;
        FallingCamera.enabled = false;
    }



    // Update is called once per frame
    void Update()
    {
        thirdPersonCamera();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;//usig -2c forces player to be on the ground
        }

        float z = Input.GetAxisRaw("Horizontal");
        //getaxisraw because dont want input smoothing just want regular input
        //horizontal axis between -1 and 1. -1 = A key or left arrow key. 1 = D key or right arrow
        float x = Input.GetAxisRaw("Vertical");
        //vertical axis between -1 and 1. -1 = W key or up arrow key. 1 = S key or down arrow key

        Vector3 direction = new Vector3(z, 0f, x).normalized;
        //Vector3 move = transform.right * x + transform.forward * z;
        //new Vector3(x, 0f, z); this means it will aways move in the same direction that the player is moving
        //transform.right which takes the direction that the player is facing and then goes to the right
        //transform.forward which takes the direction that the player is facing and then goes forward
        //vector3 stores direction, basically like an arrow in the direction we want to move
        controller.Move(direction * speed * Time.deltaTime);
        //time.deltatime makes the movement frame rate independant

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);//v=sqrt h*-2*g. the amount of velocity needed to jump a certain height
        }


        velocity.y += gravity * Time.deltaTime;//up and down axis multiplied by some gravity number
        controller.Move(velocity * Time.deltaTime);//equation for gravity = delta_y = 1/2g*t^2

        Distance = Vector3.Distance(groundCheck.transform.position, cameraChange.transform.position);
        if (Distance <= 23)
        {
            //ThirdPersonCamera.enabled = false;
            fallingCamera();
        }

        
        if (groundCheck.position.y < -0.1f)
        {
            FindObjectOfType<GameManager>().EndGame();

        }

        //animations
        //animator.SetBool("isRunning", Input.GetAxisRaw("Vertical") != 0);
        //animator.SetBool("isRunning", Input.GetAxisRaw("Horizontal") != 0);
        //animator.SetBool("isJumping", !controller.isGrounded);
    }
}
