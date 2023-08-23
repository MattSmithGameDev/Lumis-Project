using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Matt Smith (24619914)
public class LookAtTarget : MonoBehaviour
{
    [Tooltip("Set to true to have the targets look at something other than the player")]
    public bool overrideTarget = false;
    public Transform target; // The target to look at if override is true

    private void Start()
    {
        if(!overrideTarget)
            target = GameObject.Find("HeadNode").transform;
    }

    void Update()
    {
        // Look at the target
        transform.LookAt(target, Vector3.up);
    }
}
