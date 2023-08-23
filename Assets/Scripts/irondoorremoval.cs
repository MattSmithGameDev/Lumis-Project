using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author Kane Baxter (24269735)
public class irondoorremoval : MonoBehaviour
{ 
    /*The purpose of this script is to delete the final door to allow the player to proceed to the end
     */
    // Creates a public GameObject object called Iron
    public GameObject iron;



    void OnTriggerEnter()
    {
        Destroy(iron);//This destroys the GameObject iron
    }
}
