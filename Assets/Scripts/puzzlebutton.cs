using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author Kane Baxter (24269735)
public class puzzlebutton : MonoBehaviour
{
    public Light torch;//Creates a public Light component called torch


    public void torchOn()
    {
        torch.enabled = true;
    }

        protected void OnMVRWandButtonPressed(VRSelection iSelection)//When the MVRWand Presses a button to interact
        {
            this.GetComponent<Renderer>().material.color = Color.green; //Changes the material color to green
            torchOn();//Run function touchOn 
        }
}
