using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public GameObject flashLight_ground, intIcon, flashLightPlayer;
    private bool isInRange = false;

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            flashLight_ground.SetActive(false);
            intIcon.SetActive(false);
            flashLightPlayer.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Reach"))
        {
            intIcon.SetActive(true);
            isInRange = true;
        }

        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            intIcon.SetActive(false);
            isInRange = false;
        }
    }
}
