using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Matt Smith (24619914)

// Ensure the game object has a line renderer so the laser can be seen
[RequireComponent(typeof(LineRenderer))]
// Allow the laser to be updated in the editor to allow quick testing of the puzzle
[ExecuteInEditMode]
public class Laser : MonoBehaviour
{
    [Min(1)]
    public int bounces; // Number of bounces the laser will take (Must be 1 or greater)
    public GameObject particleDoor; // The particle door to the next room
    public GameObject hitParticles; // The particle gameobject to use on the final laser hit
    [Header("Target Settings")]
    public bool useHitMaterial; // Whether the material of the target should change upon completion
    public Material hitTargetMat; // The material to change the target to upon completion

    private LineRenderer lr; // The line renderer
    private bool hasHitFinalMirror; // Used to make sure the laser at least hits the
                                    // final mirror and doesn't glitch out and hit the target somehow

    private void Start()
    {
        // Get the line renderer
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RefreshLaser();
    }

    // Recalculates and renders the position of the laser.
    // Additionally carries out the detection of the mirrors and targets.
    public void RefreshLaser()
    {
        // Define the hit variable and the ray for the raycasts
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position, transform.forward);

        // Set the number of positions (how many lines) of the LineRenderer
        // to be one more than the number of bounces.
        lr.positionCount = bounces + 1;

        // Ensure first point of line renderer is on the origin
        lr.SetPosition(0, transform.position);

        // Reset final mirror check
        hasHitFinalMirror = false;

        // Loop over each bounce of the laser
        for (int i = 0; i < bounces; i++)
        {
            // Raycast the laser            
            if(Physics.Raycast(ray, out hit, 20f)){

                // Add hit point to line renderer to draw laser in game
                lr.SetPosition(i + 1, hit.point);

                // Ensure the laser hits at least the final mirror, just in case of bugs
                if (hit.collider.name == "FinalMirror") hasHitFinalMirror = true;

                // If the laser hits the target and the door still exists
                if (hit.collider.tag == "LaserTarget" && hasHitFinalMirror)
                {
                    // Change the material of the target to the completion material
                    // Also change the light
                    if (useHitMaterial)
                    {
                        hit.collider.GetComponent<Renderer>().material = hitTargetMat;
                        hit.collider.GetComponent<Light>().color = Color.cyan;
                    }

                    if (particleDoor != null)
                    {
                        // Stop emitting particles from the particle system and disable the door collider
                        particleDoor.GetComponentInChildren<ParticleSystem>().Stop();
                        particleDoor.GetComponentInChildren<BoxCollider>().enabled = false;
                        particleDoor = null;
                    }
                }
                
                if (hit.collider.tag != "Mirror")
                {
                    // Laser ends here
                    // Trim final points from line renderer
                    // +2 accounts for the origin and final point of the laser
                    lr.positionCount = i + 2;
                    break;
                }
                else
                {
                    // Update ray so it originates from the hit point and reflects correctly
                    ray.origin = hit.point;
                    ray.direction = Vector3.Reflect(ray.direction, hit.normal);
                } 
            }    
        }

        hitParticles.transform.up = hit.normal;
        hitParticles.transform.position = hit.point;
        

    }
}
