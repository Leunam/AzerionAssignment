using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 1;
    public float jumpTakeOffSpeed = 1;
    public Joystick joystick;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        if (joystick.Horizontal >= .2f || joystick.Horizontal <= -.2f)
        {
            move.x = joystick.Horizontal;
        }

        if (joystick.Horizontal != 0 && grounded)
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

        if (joystick.Vertical >= .5f && grounded)
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

        targetVelocity = move * maxSpeed;
    }
}