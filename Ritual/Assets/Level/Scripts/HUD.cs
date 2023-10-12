using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject flashLightON;
    public GameObject flashLightOFF;
    public GameObject flashLightOB;
    private FlashLight myFlashlight;
    void Start()
    {
        flashLightON.SetActive(false);
        myFlashlight = flashLightOB.GetComponent<FlashLight>();
    }
    void Update()
    {
        if (myFlashlight.on)
        {
            flashLightON.SetActive(true);
            flashLightOFF.SetActive(false);
        }

        else
        {
            flashLightON.SetActive(false);
            flashLightOFF.SetActive(true);
        }
    }
}