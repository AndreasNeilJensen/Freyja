using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    [SerializeField] Transform me;
    [SerializeField] Transform bubbles;
    [SerializeField] Transform player;
    [SerializeField] Transform deathMarker;
    [SerializeField] float movementSpeed = 1;
    [SerializeField] float lavaHeight = 60;
    [SerializeField] SoundPlayer soundPlayer;

    private bool hasPlayerBeenBelowLava = true;

    void Awake()
    {
        me = this.transform;
    }

    void Update()
    {
        // Check if the player has been below lava, and if it is currently below lava.
        // The bool has to be there in order to prevent the same horrifyingly unpleasent quack sound to be called a trillion times in a row (figuretively speaking).
        if (hasPlayerBeenBelowLava && AmIBeneathLava(player.position))
        {
            hasPlayerBeenBelowLava = false;
            InitiateDeath();
        }
    }

    void FixedUpdate()
    {
        // Move the lava up until the maximum height.
        if (me.position.y < lavaHeight)
        {
            me.Translate(Vector3.up * movementSpeed + (Vector3.up * Mathf.Sin(Time.time)) / 10, Space.World);
        }
        // "Animate" the bubbles.
        // Sin is used to get a up/down motion.
        bubbles.Translate((Vector3.up * Mathf.Sin(Time.time)) / 250);
    }

    /// <summary>
    /// Originally meant to be public I changed it to private, but were too lazy to change the variable name.
    /// simply checks if a given y position is lower than another.
    /// </summary>
    /// <param name="asker"></param>
    private bool AmIBeneathLava(Vector3 asker)
    {
        if (asker.y <= deathMarker.position.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Play the death quack and change scene after x amount of time.
    /// This had to be implemented like this because I didn't feel like implementing coroutines.
    /// </summary>
    private void InitiateDeath()
    {
        soundPlayer.PlayDeadSound();
        Invoke("LoadDeath", 1f);
    }

    /// <summary>
    /// Load the death scene baby! and embrace the sweet release of death!
    /// </summary>
    private void LoadDeath()
    {
        SceneManager.LoadScene("Death");
    }
}
