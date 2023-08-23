using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author: Matt Smith (24619914)
public class Sanity : MonoBehaviour
{
    [Header("Sanity Settings")]
    public int sanity = 600; // Score
    public int decreaseRate = 1; // How much sanity is lost per second

    [Header("Object References")]
    public Slider sanitySlider; // Reference to the sanity slider UI
    public Text sanityText; // Reference to the sanity text UI
    public GameObject winText; // A reference to the win text which is
                               // used to determine if the game is
                               // complete and the countdown should stop

    private void Start()
    {
        // Set the sliders max value to the start sanity and then start the countdown
        sanitySlider.maxValue = sanity;
        StartCoroutine(ReduceSanity());
    }

    // Reduce the sanity over the course of the game
    IEnumerator ReduceSanity()
    {
        // Until the game is completed, remove a point from the sanity every second and update the slider
        while (!winText.activeInHierarchy)
        {
            // Remove sanity and clamp to be above 0
            sanity -= decreaseRate;
            sanity = Mathf.Clamp(sanity, 0, (int) sanitySlider.maxValue);

            // Set the slider and text to reflect the sanity amount
            sanitySlider.value = sanity;
            sanityText.text = "Sanity: " + sanity;

            // Wait for 1 second
            yield return new WaitForSeconds(1);
        }
        
    }
}
