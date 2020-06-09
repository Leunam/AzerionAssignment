using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 4;
    public float jumpTakeOffSpeed = 4;
    public Joystick joystick;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        //move.x = Input.GetAxis("Horizontal");
        move.x = joystick.Horizontal;

        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") == 0)
        {
            animator.SetBool("isCharacterIdle", false);
            animator.SetBool("isCharacterJumping", false);
            animator.SetBool("isCharacterWalking", true);
        }
        else
        {
            animator.SetBool("isCharacterWalking", false);
            animator.SetBool("isCharacterJumping", false);
            animator.SetBool("isCharacterIdle", true);
        }

        if (!grounded)
        {
            animator.SetBool("isCharacterIdle", false);
            animator.SetBool("isCharacterWalking", false);
            animator.SetBool("isCharacterJumping", true);
        }
        //if (velocity.x > 0 || velocity.x < 0)
        //{
        //    //animator.SetBool("isCharacterIdle", false);
        //    //animator.SetBool("isCharacterWalking", true);
        //    animator.Play("character_walk");
        //}
        //else if (velocity.x == 0 )
        //{
        //    //animator.SetBool("isCharacterWalking", false);
        //    //animator.SetBool("isCharacterIdle", true);
        //    animator.Play("character_idle");
        //}
        
        //if (
        //    (velocity.y > 0 && velocity.x == 0) || 
        //    (velocity.y > 0 && velocity.x < 0) ||
        //    (velocity.y > 0 && velocity.x > 0))
        //{
        //    Debug.Log("DENTRO");
        //    //animator.SetBool("isCharacterIdle", false);
        //    //animator.SetBool("isCharacterJumping", true);

        //    animator.Play("character_jump");
        //}


        if (Input.GetButtonDown("Jump") && grounded)
        {

            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {

            if (velocity.y > 0)
            {

                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}