using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    private CloudSpawner spawner;
    private Transform player;

    [SerializeField] private float speed = 0.01f;
    [SerializeField] private float distanceUntilDespawn = 5f;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        // Move the cloud.
        this.transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Destroy the cloud if it gets to far away.
        if (distanceUntilDespawn < Vector3.Distance(this.transform.position, player.position))
        {
            Destroy(this.gameObject);
            spawner.currentClouds--;
        }
    }

    /// <summary>
    /// Because there is some things, like the spawner, needed to be informed on the fly by the spawner (unless I wanted to use getcomponent()... which I dont at the moment)
    /// This method is meant to (surprise) setup the spawned cloud.. I'm thinking it might contain things like direction at a later point as well... but not now..
    /// </summary>
    /// <param name="_speed"></param>
    /// <param name="_spawner"></param>
    /// <param name="_distanceUntilDespawn"></param>
    public void SetupCloud(float _speed, CloudSpawner _spawner, float _distanceUntilDespawn)
    {
        speed = _speed;
        spawner = _spawner;
        distanceUntilDespawn = _distanceUntilDespawn;
    }
}
