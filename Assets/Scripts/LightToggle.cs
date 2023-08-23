using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author - Jonathan Ely #24455474

public class LightToggle : MonoBehaviour
{
    // Creates a public Light object called 'state'
    public Light state;

    // Creates a method that when an object is detected within the zone, it changes 'state' to equal true
    void OnTriggerEnter()
    {
        state.enabled = true;
    }

}



