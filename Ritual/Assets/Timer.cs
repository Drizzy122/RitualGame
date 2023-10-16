using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float totalTimeinSeconds = 60.0f;
    public float currentTime;
    public string sceneName;
    public TMP_Text timer;


    public void Start()
    {
        currentTime = totalTimeinSeconds;
    }
    public void Update()
    {

        currentTime -= Time.deltaTime;

        currentTime = Mathf.Clamp(currentTime, 0, totalTimeinSeconds);

        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime % 60F);

        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        if (currentTime == 0.0f)
        {
            timerEnded();
            Debug.Log("Quit");
        }

    }

    void timerEnded()
    {
        SceneManager.LoadScene("JumpScare");
        //Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }


}
