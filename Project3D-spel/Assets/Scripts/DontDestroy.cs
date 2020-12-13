using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviourSingleton<InfoForScoreScene>
{

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
