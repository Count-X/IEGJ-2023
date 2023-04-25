using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TravelDistanceTimer : MonoBehaviour
{
    // This whole thing should work, but it wasn't tested...
    public TextMeshProUGUI destinationInfo;

    public bool timerActive;
    [HideInInspector] public float travelDistance;

    void Start()
    {
        timerActive = false;
    }

    void Update()
    {
        // One way to make a timer
        if (timerActive == true)
        {
            travelDistance = travelDistance + Time.deltaTime;
        }
    }

    public void TravelDestination() // Activate this when the game is lost
    {
        timerActive = false;

        // Edit this for better, if you feel like it...
        if (travelDistance >= 360)
        {
            destinationInfo.text = "Somehow we landed on the moon. We must have survived too long flying.";
        }
        else if (travelDistance >= 300)
        {
            destinationInfo.text = "Landed in Rome";
        }
        else if (travelDistance >= 240)
        {
            destinationInfo.text = "Landed in Cairo";
        }
        else if (travelDistance >= 180)
        {
            destinationInfo.text = "Landed in Dubai";
        }
        else if (travelDistance >= 120)
        {
            destinationInfo.text = "Landed in Colombo, so which one of the seven?";
        }
        else if (travelDistance >= 60)
        {
            destinationInfo.text = "Landed in Singapore, so some distance was made.";
        }
        else
        {
            destinationInfo.text = "Started from Sydney and ended up in Darwin...";
        }
    }
}
