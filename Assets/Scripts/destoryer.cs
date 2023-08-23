using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author Kane Baxter (24269735)
public class destoryer : MonoBehaviour
{
    public GameObject cage;//This allows the selection of a game object within the project.
    /*In this case the game object that is selected in the cage.prefab. This prefab has a ball on it to trigger the final door of the game
     * The trigger that was designed by Jonathon Ely is set to change the box collider to false and turn off the particle effect present on the Fog door.prefab
     */

    protected void OnMVRWandButtonPressed(VRSelection iSelection)
    {
        Destroy(cage);//This destroys the GameObject Cage
    }
}
