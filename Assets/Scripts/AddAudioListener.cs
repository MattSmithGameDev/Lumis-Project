using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Matt Smith (24619914)
public class AddAudioListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Find the main camera of the VRManager (Camera0) and add an AudioListener
        GameObject.Find("Camera0").AddComponent<AudioListener>();
    }
}
