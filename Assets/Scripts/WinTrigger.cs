using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author: Matt Smith (24619914)
public class WinTrigger : MonoBehaviour
{
    public Text winText;

    void OnMVRWandButtonPressed()
    {
        // Enable the win text and update the sanity score
        winText.gameObject.SetActive(true);
        winText.text = "You are a winner!\n" +
                        "Chicken dinner!\n" +
                        "Final Sanity: " + GameObject.Find("SanitySystem").GetComponent<Sanity>().sanity;
    }

}
