using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeTextDissepear : MonoBehaviour
{
    public Text analyseText;
    private float timeToAppear = 2f;
    private float timeWhenDisappear;
    // Start is called before the first frame update
    void Start()
    {
        analyseText.enabled = true;
        timeWhenDisappear = Time.time + timeToAppear;
    }

    // Update is called once per frame
    void Update()
    {
        if (analyseText.enabled && (Time.time >= timeWhenDisappear))
        {
            analyseText.enabled = false;
        }
    }
}
