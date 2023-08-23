using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Kane Baxter (24269735)
/*
 * Purpose of this script is to allow a player to interact with a button causing lights in the room to turn offs
 * This was coded by Kane Baxter
 */
public class TorchlightToggle : MonoBehaviour
{//Start of Public Class
    public Light torch; //Creates a public Light component called torch
    public GameObject button; //Creates a public Game Object called Button


    void OnTriggerEnter() //When an object with a collision enters the trigger zone do the following
    {
        torch.enabled = true; //Sets the component to true
        button.GetComponent<MeshRenderer>().enabled = true;//Sets component Mesh render on Game object button to true


    }
}