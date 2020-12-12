using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LisenerInfo : MonoBehaviourSingleton<InfoForScoreScene>
{
    GameObject listener;
    GameObject text;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        listener = GameObject.Find("Lisener");
        text = GameObject.Find("Audio Button");
    }

    public void Mute()
    {
        if (listener.GetComponent<AudioListener>().enabled==true)
        {
            listener.GetComponent<AudioListener>().enabled = false;
            text.GetComponentInChildren<TextMeshProUGUI>().text = "Audio: OFF";
        }
        else
        {
            listener.GetComponent<AudioListener>().enabled = true;
            text.GetComponentInChildren<TextMeshProUGUI>().text = "Audio: ON";
        }
    }
}
