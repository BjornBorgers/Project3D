using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenu : MonoBehaviour
{
    public GameObject firstMenu;
    public GameObject secondMenu;
    
    public void GoToOptions()
    {
        firstMenu.SetActive(false);
        secondMenu.SetActive(true);
    }

    public void GoBack()
    {
        firstMenu.SetActive(true);
        secondMenu.SetActive(false);
    }
}
