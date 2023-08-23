using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author - Jonathan Ely #24455474

public class DoorUnlock : MonoBehaviour
{
    // Creates a public GameObject object called 'state'
    public GameObject state;

    /* 
     * Creates a method that wdetects when an object is within the trigger zone
     * Checks the GameObject 'state' for its Children with a BoxCollider and disables it
     * Checks the GameObject 'state' for its Children with a ParticleSystem and stops emissions
     */ 
    void OnTriggerEnter()
    {
        state.GetComponentInChildren<BoxCollider>().enabled = false;
        state.GetComponentInChildren<ParticleSystem>().Stop();
    }

}
