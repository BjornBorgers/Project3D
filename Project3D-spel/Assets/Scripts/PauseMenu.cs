using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Gamemanager.Patient patient in Gamemanager.patientList)
        {
            patient.PauseTimer();
        }
    }

    // Update is called once per frame
    public void Quit()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Continue()
    {
        foreach (Gamemanager.Patient patient in Gamemanager.patientList)
        {
            patient.RestartTimer();
        }
        gameObject.SetActive(false);
    }
}
