using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterBox : MonoBehaviour
{
    public GameObject tutorialText;
    public GameObject character;
    private void OnTriggerEnter(Collider other)
    {
        tutorialText.SetActive(true);
        character.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        tutorialText.SetActive(false);
        character.SetActive(false);
    }
}
