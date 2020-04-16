using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirballonMover : MonoBehaviour
{
    private Transform balloon;
    private Vector3 balloonOrigo;
    float span;

    void Awake()
    {
        balloon = this.transform;
        balloonOrigo = balloon.position;
    }

    void FixedUpdate()
    {
        // PingPong is used to get a span between 0 and 10 which the ballooooooooooooon should move between.
        span = Mathf.PingPong(Time.time * 2.5f, 10);

        // Move deh ballon the span amount!
        balloon.position = balloonOrigo + new Vector3(0, span, 0);
    }
}
