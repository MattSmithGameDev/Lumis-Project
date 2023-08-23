using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author Kane Baxter (24269735)
public class progressbutton : MonoBehaviour
{
    public GameObject button;//Creates public game object called button


    protected void OnMVRWandButtonPressed(VRSelection iSelection)//When the MVRWand Presses a button to interact
    {
        //On press this will toggle the mesh renderer back on for the object. Making the game object visible 
        button.GetComponent<MeshRenderer>().enabled = true;
    }
}
