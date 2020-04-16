using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private int maxClouds = 10;
    public int currentClouds = 0;
    [SerializeField] private float distanceUntilDespawn = 50f;
    [SerializeField] private float spawnPerSecond = 1;
    [SerializeField] private float cloudHeightLimitUpper = 110;
    [SerializeField] private float cloudHeightLimitLower = 20;

    [SerializeField] private Transform player;
    [SerializeField] private List<Transform> clouds;

    private float cloudSpawnTimer = 0;

    void Update()
    {

        // Update the time
        cloudSpawnTimer += Time.deltaTime;

        // Make sure that it's the correct time to spawn a cloud, that not too many clouds are spawned and that the player is at an appropriate height for clouds to spawn.
        if (cloudSpawnTimer >= spawnPerSecond && currentClouds < maxClouds && player.position.y >= cloudHeightLimitLower && player.position.y <= cloudHeightLimitUpper)
        {
            // Reset the timer.
            cloudSpawnTimer = 0.0f;

            SpawnCloud();
        }
    }


    /// <summary>
    /// Gets a random Vector3 near the player.
    /// </summary>
    public Vector3 GetRandomSpawn()
    {
        return new Vector3(player.position.x - distanceUntilDespawn + 5, player.position.y + Random.Range(3, 15), 0);
    }

    /// <summary>
    /// Spawns a random cloud at a random position and run the SetupCloud method on said cloud.
    /// </summary>
    private void SpawnCloud()
    {
        // Instantiate the cloud and save it to local variable; cloud.
        Transform cloud = Instantiate(GetRandomCloud(), GetRandomSpawn(), Quaternion.identity);

        // Run the SetupCloud method on the cloud.
        cloud.GetComponent<CloudMover>().SetupCloud(Random.Range(1, 10), this, distanceUntilDespawn);

        // Increment the current amount of clouds spawned.
        currentClouds++;
    }

    /// <summary>
    /// Returns a random cloud from the clouds array.
    /// </summary>
    private Transform GetRandomCloud()
    {
        return clouds[Random.Range(0, clouds.Count)];
    }
}
