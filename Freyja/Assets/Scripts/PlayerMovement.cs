using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private float moveSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jumping = false;

    void Update()
    {
        // Get direction/amount to move.
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
        }

        // Move player.
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jumping);
        jumping = false;
    }
}
