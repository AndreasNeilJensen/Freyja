using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private float prefferedY = 5f;
    [SerializeField] private float prefferedZ = -7.5f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, prefferedY, prefferedZ));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
