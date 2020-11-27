using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using TMPro;
using System;

public class InfoForScoreScene : MonoBehaviourSingleton<InfoForScoreScene>
{
    public GameObject gamemanager;
    public GameObject timertext;

    public GameObject patientA;
    public GameObject patientB;
    public GameObject patientC;

    public bool ASaved;
    public bool BSaved;
    public bool CSaved;

    TimeSpan elapsed; // however you get the amount of time elapsed

    public Stopwatch playTimer = new Stopwatch();
    // Start is called before the first frame update
    void Start()
    {
        patientA = gamemanager.GetComponent<Gamemanager>().patientA;
        patientB = gamemanager.GetComponent<Gamemanager>().patientB;
        patientC = gamemanager.GetComponent<Gamemanager>().patientC;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name=="SampleScene")
        {
            ASaved = patientA.GetComponent<Patient>().isSaved;
            BSaved = patientB.GetComponent<Patient>().isSaved;
            CSaved = patientC.GetComponent<Patient>().isSaved;
            DontDestroyOnLoad(this.gameObject);
            elapsed = playTimer.Elapsed;
            string tsOut = elapsed.ToString(@"m\:ss");
            timertext.GetComponent<TextMeshProUGUI>().text = tsOut;
        }
    }

    public void StartTimer()
    {
        playTimer.Restart();
    }

    public void StopTimer()
    {
        playTimer.Stop();
    }
}
