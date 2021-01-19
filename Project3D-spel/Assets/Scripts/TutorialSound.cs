using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSound : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject triageColor;

    public GameObject arrow;
    public float interval;

    public void Start()
    {
        arrow.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        InvokeRepeating("FlashLabel", 0, interval);
        arrow.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        FlashLabel();
    }
    private void OnTriggerExit(Collider other)
    {
        arrow.SetActive(false);
    }
    void FlashLabel()
    {
        if (triageColor.activeSelf)
            triageColor.SetActive(false);
        else
            triageColor.SetActive(true);
    }
}
