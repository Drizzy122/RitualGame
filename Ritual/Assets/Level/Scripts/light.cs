using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public GameObject flashLight_ground, intIcon, flashLightPlayer;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)) {
                flashLight_ground.SetActive(false);
                intIcon.SetActive(false);
                flashLightPlayer.SetActive(true);
            }
        }

        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
        }
    }
}
