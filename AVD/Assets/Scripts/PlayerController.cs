using System.Collections;
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
    private Rigidbody2D rb;

    public Transform bulletStart;

    private void Start()
    {
        Physics2D.gravity = new Vector2(0, Gravity2D);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("hVelocity", Mathf.Abs(horizontalMove));
        animator.SetFloat("vVelocity", rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("jumping", true); 
        }
        if (Input.GetButtonUp("Jump"))
        {
            jump = false;
            animator.SetBool("jumping", false);
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
        animator.SetBool("jumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("crouching", isCrouching); 
    }

    public void Hited()
    {
        animator.SetTrigger("damaged");
    }

    void FixedUpdate()
    {
        // Move our character 
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }
}
