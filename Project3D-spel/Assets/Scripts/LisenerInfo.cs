using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LisenerInfo : MonoBehaviourSingleton<InfoForScoreScene>
{
    GameObject listener;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        listener = GameObject.Find("Lisener");
    }

    public void Mute()
    {
        if (listener.GetComponent<AudioListener>().enabled==true)
        {
            listener.GetComponent<AudioListener>().enabled = false;
        }
        else
        {
            listener.GetComponent<AudioListener>().enabled = true;
        }
    }
}
