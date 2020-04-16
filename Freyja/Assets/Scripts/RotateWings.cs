using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a pretty damn simple script, so I won't bother commenting...
/// Except to say that the script controls the rotation of the windmill wings..
/// </summary>
public class RotateWings : MonoBehaviour
{
    [SerializeField] private Transform cylinder;

    void Awake()
    {
        cylinder = this.transform;
    }

    void FixedUpdate()
    {
        cylinder.Rotate(Vector3.up, -1);
    }
}
