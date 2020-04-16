using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class should be pretty self-explanatory, it constantly moves the credits forward and then resets the position.
/// </summary>
public class CreditsRollScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private Vector3 startingPosition;
    private Transform credits;

    void Awake()
    {
        credits = this.transform;
        startingPosition = credits.position;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(credits.position, startingPosition) > distance)
        {
            credits.position = startingPosition;
        }

        credits.position += (credits.TransformDirection(Vector3.left) / 100 ) * speed;
    }
}
