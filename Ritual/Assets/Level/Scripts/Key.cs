using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject intIcon, key;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                key.SetActive(false);
                door.keyFound = true;
                intIcon.SetActive(false);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
        }
    }
}
