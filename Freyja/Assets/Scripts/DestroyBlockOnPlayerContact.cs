using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a super simple class whose only purpose is to delete a single GameObject, when this is done, the script will be removed from the GameObject.
/// </summary>
public class DestroyBlockOnPlayerContact : MonoBehaviour
{
    [SerializeField] private SmoothCameraFollower camera;
    [SerializeField] private float requiredDistance;
    [SerializeField] private float countdown = 5f;
    [SerializeField] private Transform boulder;
    [SerializeField] private Transform player;
    private bool triggerOnceOnly = true;
    private Transform me;

    void Awake()
    {
        me = this.transform;
    }

    /// <summary>
    /// triggerOnceOnly is used in order to ensure that the player 
    /// is placed at the Contact point for countdown amount of seconds in ONE straight go!
    /// </summary>
    void FixedUpdate()
    {
        if (triggerOnceOnly && ShouldBoulderBeBroken())
        {
            triggerOnceOnly = false;
            Invoke("Trigger", countdown);
        }
    }

    /// <summary>
    /// Check if the boulder should be broken.
    /// </summary>
    bool ShouldBoulderBeBroken()
    {
        if (Vector3.Distance(me.position, player.position) < requiredDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Have to use a seperate function here in order to enable usage of Invoke.
    /// </summary>
    void Trigger()
    {
        if (ShouldBoulderBeBroken())
        {
            BreakBoulder();
            RemoveScript();
        }
        else
        {
            triggerOnceOnly = true;
        }
    }

    /// <summary>
    /// 10 DKK says you won't guess what this method does..
    /// </summary>
    void BreakBoulder()
    {
        Destroy(boulder.gameObject);
    }

    /// <summary>
    /// You will almost certainly never ever guess what this method does.
    /// </summary>
    void RemoveScript()
    {
        Destroy(GetComponent<DestroyBlockOnPlayerContact>());
    }
}
