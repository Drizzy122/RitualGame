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

    public GameObject Granny;

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
        Granny = GameObject.FindWithTag("Granny");
        if (Input.GetButtonDown("Interact") && inReach)
        {
            Granny.GetComponent<monsterChase>().Pills = true;
            // Disable the specific BoxCollider
            if (specificCollider != null)
            {
                specificCollider.enabled = false;
            }
            Invoke(nameof(EndScene),1f);
            pickUpSound.Play();
            inReach = false;
            pickUpText.SetActive(false);
            Destroy(gameObject);
        }

    }
    private void EndScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
