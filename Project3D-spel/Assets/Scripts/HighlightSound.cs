using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class HighlightSound : MonoBehaviour
{
    public AudioSource soundEffect;
    public AudioClip highlightSound;

    public void HoverSound()
    {
        soundEffect.PlayOneShot(highlightSound);
    }
}
