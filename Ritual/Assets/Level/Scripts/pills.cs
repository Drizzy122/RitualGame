using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pills : MonoBehaviour
{
    private bool inReach;

    public GameObject pickUpText;
    public GameObject pill;
    public CapsuleCollider specificCollider;
    public AudioSource pickUpSound; 
    public string sceneName;

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach)
        {
            GetComponent<monsterChase>().enabled = false;
            // Disable the specific BoxCollider
            if (specificCollider != null)
            {
                specificCollider.enabled = false;
            }
            SceneManager.LoadScene(sceneName);
            pickUpSound.Play();
            inReach = false;
            pickUpText.SetActive(false);
            Destroy(gameObject);
        }

    }
}
