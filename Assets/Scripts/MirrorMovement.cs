using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Matt Smith (24619914)
public class MirrorMovement : MonoBehaviour
{
    // Lock toggles
    [Header("Axis Locks")]
    // Axis locks are aligned to world space axes
    public bool lockXAxis;
    public bool lockYAxis;
    public bool lockZAxis;

    [Header("Rotation Lock")]
    public bool rotationLock;

    // Movement Constraints
    [Header("Movement Constraints")]
    // Constraints apply in local space
    public bool constrainX;
    public float xMin;
    public float xMax;
    [Space]
    public bool constrainY;
    public float yMin;
    public float yMax;
    [Space]
    public bool constrainZ;
    public float zMin;
    public float zMax;

    // Positon and rotation at runtime
    private Vector3 lockedVector;
    private Quaternion lockedRotation;

    private void Start()
    {
        // Get the position and rotation at runtime
        lockedVector = transform.position;
        lockedRotation = transform.rotation;
    }

    // Event caused on this object each frame the VRWand is grabbing it
    // This causes locking and clamping to only occur while the object is actually being moved, which is far more performant
    private void VRAction()
    {
        ApplyAxisLock();
        ApplyRotLock();
        ConstrainMovement();
    }

    // Event caused on this object when the VRWand lets go
    private void OnMVRWandButtonReleased()
    {
        // Call the delayed lock methods 1 frame after the trigger is released
        StartCoroutine(DelayAxisLock());
        StartCoroutine(DelayRotLock());
        StartCoroutine(DelayConstraint());
    }

    private void ApplyAxisLock()
    {
        // Exit early if no axes are locked
        if (!lockXAxis && !lockYAxis && !lockZAxis) return;

        // Lock the position
        // If the axis isn't locked, update the locked axis vector with the new positions
        if (!lockXAxis)
        {
            lockedVector.x = transform.position.x;
        }

        if (!lockYAxis)
        {
            lockedVector.y = transform.position.y;
        }

        if (!lockZAxis)
        {
            lockedVector.z = transform.position.z;
        }

        // Move the transform to the new values of locked vector
        transform.position = lockedVector;
    }

    // Call the ApplyLock() method with a 1 frame delay before execution
    private IEnumerator DelayAxisLock()
    {
        // Leading with this causes an intentional 1 frame delay
        yield return null;
        ApplyAxisLock();
    }

    private void ApplyRotLock()
    {
        // Set the locked rotation to the current rotation if rotation is not being locked
        if (!rotationLock)
        {
            lockedRotation = transform.rotation;
        }

        // Set the current rotation to the value of the lockedRotation
        transform.rotation = lockedRotation;

    }

    // Call the ApplyRotLock() method with a 1 frame delay before execution
    private IEnumerator DelayRotLock()
    {
        // Leading with this causes an intentional 1 frame delay
        yield return null;
        ApplyRotLock();
    }

    private void ConstrainMovement()
    {
        // Exit early if no axes are being clamped
        if (!constrainX && !constrainY && !constrainZ) return;

        // Create a new vector with the current position
        Vector3 clampedVector = transform.localPosition;

        // Clamp any constrained axes and update the new vector
        if (constrainX)
        {
            clampedVector.x = Mathf.Clamp(clampedVector.x, xMin, xMax);
        }

        if (constrainY)
        {
            clampedVector.y = Mathf.Clamp(clampedVector.y, yMin, yMax);
        }

        if (constrainZ)
        {
            clampedVector.z = Mathf.Clamp(clampedVector.z, zMin, zMax);
        }

        // Set the localPosition to the clamped vector
        transform.localPosition = clampedVector;
    }

    // Call the ConstrainMovement() method with a 1 frame delay before execution
    private IEnumerator DelayConstraint()
    {
        // Leading with this causes an intentional 1 frame delay
        yield return null;
        ConstrainMovement();
    }
}
