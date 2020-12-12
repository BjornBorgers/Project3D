using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlChoose : MonoBehaviourSingleton<InfoForScoreScene>
{
    public bool altControls = false;
   

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
