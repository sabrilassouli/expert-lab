using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    private Animator animator;
    public float baseSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 5f;
    public bool isInteracting = false;
    public bool pauzed = false;

    public GameObject Gun;
    public GameObject Tazer;
    public GameObject Handcuffs;

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
        //gun
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Gun.SetActive(true);
            Tazer.SetActive(false);
            Handcuffs.SetActive(false);
        }
        //tazer
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Gun.SetActive(false);
            Tazer.SetActive(true);
            Handcuffs.SetActive(false);
        }
        //handcuffs
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Gun.SetActive(false);
            Tazer.SetActive(false);
            Handcuffs.SetActive(true);
        }
        //handcuffs
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauzed == true)
            {
                Time.timeScale = 1;
                pauzed = false;
            }
            else if (pauzed == false)
            {
                Time.timeScale = 0;
                pauzed = true;
            }
        }
    }
    public void talking()
    {
        Gun.SetActive(false);
        Tazer.SetActive(false);
        Handcuffs.SetActive(false);
    }
    public void MouseLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
