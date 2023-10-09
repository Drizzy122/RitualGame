using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Key : MonoBehaviour
{
    public GameObject intIcon, key;
    public door Door;  // Assuming you have a reference to the Door script

    void Update()
    {
        if (IsEKeyPressed())
        {
            HandleEKey();
        }
    }

    bool IsEKeyPressed()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    void HandleEKey()
    {
        if (key.activeSelf)
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
