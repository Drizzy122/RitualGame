using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    public Light lighting;
    public TMP_Text text;
    public TMP_Text batteryText;
    public Image batteryBar;
    private Color barColor = Color.green;
    public float lifetime = 100;
    public float batteries = 0;
    public AudioSource flashON;
    public AudioSource flashOFF;
    private bool on;
    private bool off;
    void Start()
    {
        lighting = GetComponent<Light>();

        off = true;
        lighting.enabled = false;

    }
    void Update()
    {
        batteryBar.fillAmount = Mathf.Clamp(lifetime / 100, 0, 1f);
        batteryBar.color = barColor;
        text.text = lifetime.ToString("0") + "%";
        batteryText.text = batteries.ToString();

        if (Input.GetButtonDown("flashlight") && off)
        {
            flashON.Play();
            lighting.enabled = true;
            on = true;
            off = false;
        }

        else if (Input.GetButtonDown("flashlight") && on)
        {
            flashOFF.Play();
            lighting.enabled = false;
            on = false;
            off = true;
        }

        if (on)
        {
            lifetime -= 1 * Time.deltaTime;
        }

        if (lifetime <= 0)
        {
            lighting.enabled = false;
            on = false;
            off = true;
            lifetime = 0;
        }

        if(lifetime == 0)
        {
            barColor = Color.green;
        }

        if (lifetime >= 100)
        {
            lifetime = 100;
        }
        

        if(lifetime >= 50f)
        {
            barColor.r = 2 - (2 * lifetime) / 100;
        }
        else if(lifetime >0)
        {
            barColor.g = 2 * lifetime / 100;
        }

        if (Input.GetButtonDown("reload") && batteries >= 1)
        {
            batteries -= 1;
            lifetime += 50;
        }

        if (Input.GetButtonDown("reload") && batteries == 0)
        {
            return;
        }

        if (batteries <= 0)
        {
            batteries = 0;
        }
    }
}