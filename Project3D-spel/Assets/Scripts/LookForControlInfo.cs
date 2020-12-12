using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LookForControlInfo : MonoBehaviour
{
    GameObject infoControls;
    GameObject text;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        infoControls = GameObject.Find("ControlInfo");
        text = GameObject.Find("Control Button");
    }

    public void SwitchControls()
    {
        if (infoControls.GetComponent<ControlChoose>().altControls == false)
        {
            infoControls.GetComponent<ControlChoose>().altControls = true;
            text.GetComponentInChildren<TextMeshProUGUI>().text = "Controls: WASD";
        }
        else
        {
            infoControls.GetComponent<ControlChoose>().altControls = false;
            text.GetComponentInChildren<TextMeshProUGUI>().text = "Controls: ZQSD";
        }
    }
}
