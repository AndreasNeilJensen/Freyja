using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioSource playerCrazyAudioSource;
    [SerializeField] private AudioClip jumpAudioClip;
    [SerializeField] private AudioClip runningAudioClip;
    [SerializeField] private AudioClip idleAudioClip;
    [SerializeField] private AudioClip deadAudioClip;
    [SerializeField] private AudioClip winAudioClip;
    [SerializeField] private AudioClip musicAudioClip;

    private bool axisUseSingleFireBool = false;
    private bool axisNotInUseSingleFireBool = false;

    void Start()
    {
        PlayMusic();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayJumpSound();
        }

        // Only if the player is moving horizontally should the SoundPlayer play the braindead running quack sound.
        // The bool is there to prevent spamming the same method each frame.
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (axisUseSingleFireBool == false)
            {
                axisUseSingleFireBool = true;
                PlayRunningSound();
            }
        }
        else
        {
            axisUseSingleFireBool = false;
        }

        // Only if the player is moving horizontally should the SoundPlayer play the braindead idle quack sound.
        // The bool is there to prevent spamming the same method each frame.
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if (axisNotInUseSingleFireBool == false)
            {
                axisNotInUseSingleFireBool = true;
                PlayIdleSound();
            }
        }
        else
        {
            axisNotInUseSingleFireBool = false;
        }
    }


    /// <summary>
    /// Play the music.
    /// </summary>
    private void PlayMusic()
    {
        musicAudioSource.clip = musicAudioClip;
        musicAudioSource.Play();
    }

    /// <summary>
    /// Play the god forsaken jumping quack sound.
    /// </summary>
    private void PlayJumpSound()
    {
        playerCrazyAudioSource.clip = jumpAudioClip;
        playerCrazyAudioSource.Play();
    }

    /// <summary>
    /// Play the horribly running quack sound.
    /// </summary>
    private void PlayRunningSound()
    {
        playerAudioSource.clip = runningAudioClip;
        playerAudioSource.Play();
    }

    /// <summary>
    /// Dear god, what have I done...
    /// ... Play the horrifying idle quack...
    /// </summary>
    private void PlayIdleSound()
    {
        playerAudioSource.clip = idleAudioClip;
        playerAudioSource.Play();
    }

    /// <summary>
    /// Finally there is sollace for my suffering..
    /// Embrace soothing death with one last gaping quack..
    /// </summary>
    public void PlayDeadSound()
    {
        playerCrazyAudioSource.clip = deadAudioClip;
        playerCrazyAudioSource.Play();
    }
}
