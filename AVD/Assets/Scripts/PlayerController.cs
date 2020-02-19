﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public float Gravity2D = -30f;

    private void ChangeGravity(float g)
    {
    }


    private void Start()
    {
        Physics2D.gravity = new Vector2(0, Gravity2D);
    }

    void Update()

    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        Debug.Log(horizontalMove);

        // animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            //  animator.SetBool("IsJumping", true); 
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        // animator.SetBool("IsJumping", false); 
    }

    public void OnCrouching(bool isCrouching)
    {
        //   animator.SetBool("IsCrouching", isCrouching); 

    }



    void FixedUpdate()
    {
        // Move our character 
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;
    }
}