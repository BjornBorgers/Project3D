using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class InfoForScoreScene : MonoBehaviourSingleton<InfoForScoreScene>
{
    public GameObject gamemanager;

    public bool doneA;
    public bool doneB;
    public bool doneC;

    GameObject patientA;
    GameObject patientB;
    GameObject patientC;

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
