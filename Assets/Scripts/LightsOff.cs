using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOff : MonoBehaviour
{
    GameObject player; /// Sets the player as the Camera so the script works
    public GameObject[] lights;
    private bool lightEnabled;
    void Start()
    {
        player = GameObject.Find("Camera0");
    }

    void Update()
       {
        if (player.transform.position.x >= 7.25f && player.transform.position.x <= 8.7f && player.transform.position.z >= 3.785f && player.transform.position.z <= 4.25f) {
            lightEnabled = false;
            foreach (var light in lights)
            {
                light.SetActive(lightEnabled);
            }
          }

    
}
    
}  
