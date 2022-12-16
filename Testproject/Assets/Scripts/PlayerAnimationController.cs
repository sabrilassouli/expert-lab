using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update

    void start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // forward
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        //jump
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
        //back
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("RunBack", true);
        }
        else
        {
            animator.SetBool("RunBack", false);
        }

        //left
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("StrafeLeft", true);
        }
        else
        {
            animator.SetBool("StrafeLeft", false);
        }

        //right
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("StrafeRight", true);
        }
        else
        {
            animator.SetBool("StrafeRight", false);
        }

    }
}
