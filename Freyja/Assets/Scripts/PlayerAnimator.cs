using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public PlayerController controller;

    public Transform leftHip;
    public Vector3 leftHipOrigo;

    public Transform rightHip;
    public Vector3 rightHipOrigo;

    public Transform leftWing;
    public Vector3 leftWingOrigo;

    public Transform rightWing;
    public Vector3 rightWingOrigo;

    public Transform body;
    public Vector3 bodyOrigo;

    private bool axisInUse = false;

    /// <summary>
    /// Get the starting angles of each appendage in order to know, for example, which direction the hips of a duck should normally turn..
    /// because basically this ducks appendages moves in ways previously only thought possible in horror movies.
    /// </summary>
    void Start()
    {
        leftHipOrigo = leftHip.eulerAngles;
        rightHipOrigo = rightHip.eulerAngles;
        leftWingOrigo = leftWing.eulerAngles;
        rightWingOrigo = rightWing.eulerAngles;
    }

    void Update()
    {
        // If the player is moving the character sideways, then dat duck better start waddlin n' flappin!
        // If not, then go into idle mode and flap like a normal duck/turkey/chicken freak of nature ..
        // The bool is there to prevent the same method being spammed each frame, which is what Update() does for anyone who don't know.
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Waddle();
            if (axisInUse == false)
            {
                axisInUse = true;
                WildFlap();
                WildBody();
            }
        }
        else
        {
            axisInUse = false;
            ResetWaddle();
            IdleBody();
            IdleFlap();
        }
    }

    /// <summary>
    /// This basically turns and twists the ducks hips in a circle like one would at a... when you... hmm.. nah
    /// I can't figure out a way to make a joke about this without turning it sexual, and that would be inappropriate.
    /// </summary>
    void Waddle()
    {
        leftHip.Rotate(0, 0, 99999 * Time.deltaTime);
        rightHip.Rotate(0, 0, 99999 * Time.deltaTime);
    }

    /// <summary>
    /// Pop those old hips back into their sockets duckie!
    /// </summary>
    void ResetWaddle()
    {
        leftHip.eulerAngles = leftHipOrigo;
        rightHip.eulerAngles = rightHipOrigo;
    }

    /// <summary>
    /// Flap like you're nuggets depended on it!
    /// </summary>
    void WildFlap()
    {
        float angle = Mathf.PingPong(Time.time * 2000, 90) - 90;

        leftWing.rotation = Quaternion.AngleAxis(angle, Vector3.right + new Vector3(0, 0.5f, 0));
        rightWing.rotation = Quaternion.AngleAxis(angle, Vector3.left + new Vector3(0, 0.5f, 0));
    }

    /// <summary>
    /// Calm flappies, nice flappies, soothing flappies.
    /// </summary>
    void IdleFlap()
    {
        float angle = Mathf.PingPong(Time.time * 200, 75) - 90;

        leftWing.rotation = Quaternion.AngleAxis(angle, Vector3.right);
        rightWing.rotation = Quaternion.AngleAxis(angle, Vector3.left);
    }

    /// <summary>
    /// Rock the body of the chicken back and fourth like a old person in a retirement home.
    /// </summary>
    void IdleBody()
    {
        // PingPong returns a value between the current time and 10 using modulo, this is used to get an appropriate angle for animation.
        float angle = Mathf.PingPong(Time.time * 10, 10) - 15;

        if (!controller.FacingRightCheck())
        {
            body.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        }
        else
        {
            body.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    /// <summary>
    /// Oh shit! the player wants to move!
    /// better start jiggling my bits!
    /// </summary>
    void WildBody()
    {
        // PingPong returns a value between the current time and 30 using modulo, this is used to get an appropriate angle for animation.
        float angle = Mathf.PingPong(Time.time * 400, 30) - 35;

        // Due to the way I'm handling animation I have to check the direction the player is facing!
        if (!controller.FacingRightCheck())
        {
            body.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        }
        else
        {
            body.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
