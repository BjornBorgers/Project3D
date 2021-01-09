using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            text.GetComponentInChildren<TextMeshProUGUI>().text = "Audio: OFF";
        }
        else
        {
            AudioListener.volume = 1;
            text.GetComponentInChildren<TextMeshProUGUI>().text = "Audio: ON";
        }
    }
}
