using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform GroundCheck;                           // A position marking where to check if the player is grounded.

    const float GroundedRadius = 0.5f; // Radius of the overlap circle to determine if grounded
    private bool Grounded;            // Whether or not the player is grounded.
    private Rigidbody2D Rigidbody2D;
    private bool facingRight = true;  // For determining which way the player is currently facing.
    private Vector3 Velocity = Vector3.zero;

    public bool moving = false;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = Grounded;
        Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                Grounded = true;
            }
        }
    }


    public void Move(float move, bool crouch, bool jump)
    {
        // Only control the player if grounded or airControl is turned on
        if (Grounded || AirControl)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            Rigidbody2D.velocity = Vector3.SmoothDamp(Rigidbody2D.velocity, targetVelocity, ref Velocity, MovementSmoothing);

            if (move != 0)
            {
                moving = true;
            }
            else
            {
                moving = false;
            }

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !facingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && facingRight)
            {
                // ... flip the player.
                Flip();
            }
        }

        // If the player should jump...
        if (Grounded && jump)
        {
            // Add a vertical force to the player.
            Grounded = false;
            Rigidbody2D.AddForce(new Vector2(0f, JumpForce));
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    /// <summary>
    /// Enables other classes to know the direction the player is facing.
    /// </summary>
    public bool FacingRightCheck()
    {
        return facingRight;
    }
}
