using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Key : MonoBehaviour
{
    public GameObject intIcon, key;
    private bool isInRange = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            key.SetActive(false);
            door.keyFound = true;
            intIcon.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);
            isInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
            isInRange = false;
        }
    }
}
