using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    public float baseSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 5f;

    float speedBoost = 1f;
    Vector3 velocity;

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButton("Fire3"))
            speedBoost = sprintSpeed;
        else
            speedBoost = 1f;


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (baseSpeed + speedBoost) * Time.deltaTime);

        //    if (Input.GetButtonDown("Jump") && controller.isGrounded)
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
