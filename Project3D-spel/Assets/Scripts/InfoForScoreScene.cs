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

    public Color truePatientAColor;
    public Color truePatientBColor;
    public Color truePatientCColor;

    public Color patientAColor;
    public Color patientBColor;
    public Color patientCColor;

    public GameObject radialmenu;

    public bool isSetUp;
    public int penaltyPoints;

    TimeSpan elapsed; // however you get the amount of time elapsed

    public Stopwatch playTimer = new Stopwatch();
    // Start is called before the first frame update
    void Start()
    {
        patientA = gamemanager.GetComponent<Gamemanager>().patientA;
        patientB = gamemanager.GetComponent<Gamemanager>().patientB;
        patientC = gamemanager.GetComponent<Gamemanager>().patientC;


        switch (gamemanager.GetComponent<Gamemanager>().patientA.GetComponent<Patient>().level)
        {
            case TraigeLevel.Blue:
                truePatientAColor = Color.blue;
                break;
            case TraigeLevel.Green:
                truePatientAColor = Color.green;
                break;
            case TraigeLevel.Yellow:
                truePatientAColor = new Color(255, 100, 0);
                break;
            case TraigeLevel.Orange:
                truePatientAColor = Color.yellow;
                break;
            case TraigeLevel.Red:
                truePatientAColor = Color.red;
                break;
            case TraigeLevel.Black:
                truePatientAColor = Color.black;
                break;
            default:
                break;
        }
        switch (gamemanager.GetComponent<Gamemanager>().patientB.GetComponent<Patient>().level)
        {
            case TraigeLevel.Blue:
                truePatientBColor = Color.blue;
                break;
            case TraigeLevel.Green:
                truePatientBColor = Color.green;
                break;
            case TraigeLevel.Yellow:
                truePatientBColor = new Color(255, 100, 0);
                break;
            case TraigeLevel.Orange:
                truePatientBColor = Color.yellow;
                break;
            case TraigeLevel.Red:
                truePatientBColor = Color.red;
                break;
            case TraigeLevel.Black:
                truePatientBColor = Color.black;
                break;
            default:
                break;
        }
        switch (gamemanager.GetComponent<Gamemanager>().patientC.GetComponent<Patient>().level)
        {
            case TraigeLevel.Blue:
                truePatientCColor = Color.blue;
                break;
            case TraigeLevel.Green:
                truePatientCColor = Color.green;
                break;
            case TraigeLevel.Yellow:
                truePatientCColor = new Color(255, 100, 0);
                break;
            case TraigeLevel.Orange:
                truePatientCColor = Color.yellow;
                break;
            case TraigeLevel.Red:
                truePatientCColor = Color.red;
                break;
            case TraigeLevel.Black:
                truePatientCColor = Color.black;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name=="SampleScene")
        {
            ASaved = patientA.GetComponent<Patient>().isSaved;
            BSaved = patientB.GetComponent<Patient>().isSaved;
            CSaved = patientC.GetComponent<Patient>().isSaved;
            penaltyPoints = radialmenu.GetComponent<MenuScript>().penalty;
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

    public void UnpauzeTimer()
    {
        playTimer.Start();
    }
}
