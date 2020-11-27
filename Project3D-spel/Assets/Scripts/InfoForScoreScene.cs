using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using TMPro;
using System;

public class InfoForScoreScene : MonoBehaviourSingleton<InfoForScoreScene>
{
    public GameObject gamemanager;
    public GameObject timertext;

    public bool doneA;
    public bool doneB;
    public bool doneC;

    GameObject patientA;
    GameObject patientB;
    GameObject patientC;

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
        doneA = patientA.GetComponent<Patient>().isDead;
        doneB = patientA.GetComponent<Patient>().isDead;
        doneC = patientA.GetComponent<Patient>().isDead;
        DontDestroyOnLoad(this.gameObject);
        elapsed = playTimer.Elapsed;
        string tsOut = elapsed.ToString(@"m\:ss");
        timertext.GetComponent<TextMeshProUGUI>().text = tsOut;
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
