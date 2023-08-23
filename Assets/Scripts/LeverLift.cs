using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author - Jonathan Ely #24455474

public class LeverLift : MonoBehaviour
{
    /*
     * Creates a public GameObject called 'lever1'
     * Creates a public GameObject called 'lever2'
     * Creates a public GameObject called 'lever3'
     * Creates a public GameObject called 'lever4'
     * Creates a public bool called 'completed'
     */
    public GameObject lever1;
    public GameObject lever2;
    public GameObject lever3;
    public GameObject lever4;

    public bool completed;

    /*
     * Creates a Update method that checks every frame
     * Creates an If statement to check if the 4 lever GameObjects are in the correct y position and also checks if the bool completed is false 
     * Within the If statement, it sets the bool completed to equal true
     * Finds the GameObject SanitySystem and adds 120 to the sanity
     */ 
    private void Update()
    {
        if (lever1.transform.localPosition.y == 2 && lever2.transform.localPosition.y == 1 && lever3.transform.localPosition.y == 2 && lever4.transform.localPosition.y == 1 && !completed)
        {
            completed = true;
            GameObject.Find("SanitySystem").GetComponent<Sanity>().sanity += 120;
        }
    }
}
