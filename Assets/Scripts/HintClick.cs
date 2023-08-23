
//Author Kane Baxter (24269735)
using UnityEngine;
using UnityEngine.UI;

public class HintClick : MonoBehaviour
{
    public Text state;//creates a public text object called state


    private void popUpOn()//This determines 
    {
        state.enabled = true;//Changes Text in canvas's state to true
    }
    private void popUpOff()//This determines 
    {
        state.enabled = false;//Changes Text in canvas's state to true
    }

    protected void OnMVRWandButtonPressed(VRSelection iSelection) //When the MVRWand Presses a button to interact
    {   
        this.GetComponent<Renderer>().material.color = Color.green;//Changes the material color to green
        popUpOn();//Start Function "popUpOn"
    }
    protected void OnMVRWandButtonReleased(VRSelection iSelection)//When the MVRWand Presses a button to interact
    {
        this.GetComponent<Renderer>().material.color = Color.red;//Changes the material color to red
        popUpOff(); //Start Function "popUpOn"
    }
 



}
