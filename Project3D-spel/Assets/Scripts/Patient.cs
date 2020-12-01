﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine.Video;

public enum TraigeLevel
{
    Blue = 0,
    Green = 1,
    Yellow = 2,
    Orange = 3,
    Red = 4,
    Black = 5,
} //level traige determens how bad het is with a patient

public class Patient : MonoBehaviour
{
    public GameObject text;
    public GameObject radialMenu;
    public GameObject heartText;
    public GameObject heartVisuale;
    public GameObject boneArm;
    public GameObject boneLeg;
    public GameObject armSpaak;
    public GameObject legSpaak;
    public GameObject bindingSpaak;
    public VideoClip heartClip;
    public VideoClip blackClip;
    public Animator patientAnimator;

    public TraigeLevel level;
    Stopwatch lifeTimer = new Stopwatch();
    public bool heartProblem;
    public bool breathingProblem;
    public bool armProblem;
    public bool legProblem;
    public bool onbewust;

    public GameObject InfoPatientAll;
    public Image InfoBewust;
    public Image InfoLung;
    public Image InfoLeg;
    public Image InfoArm;
    public Image InfoAirway;

    public GameObject TriageBackGroundA;
    public GameObject TriageBackGroundB;
    public GameObject TriageBackGroundC;

    Color currentColorA;
    Color currentColorB;
    Color currentColorC;

    int timeToLife;
    private float timeWhenDisappear;
    private float timeToAppear = 1f;
    private float timeToBlink;
    public bool isDead = false;
    public bool isSaved = false;
    public bool isDone = false;
    bool warning = false;
    bool waiting = false;
    public List<IProblems> problemsList = new List<IProblems>();


    // Start is called before the first frame update
    void Start()
    {
        switch (level)
        {
            case TraigeLevel.Blue:
                isSaved = true;
                timeToLife = 420000;
                break;
            case TraigeLevel.Green:
                timeToLife = 360000;
                break;
            case TraigeLevel.Yellow:
                timeToLife = 240000;
                break;
            case TraigeLevel.Orange:
                timeToLife = 180000;
                break;
            case TraigeLevel.Red:
                timeToLife = 120000;
                break;
            case TraigeLevel.Black:
                isDead = true;
                timeToLife = 60000;
                break;
            default:
                break;
        }

        StartTimer();

        if (heartProblem == true)
        {
            HeartStopped heart = new HeartStopped();
            problemsList.Add(heart);
            patientAnimator.SetTrigger("IsOnBewust");
        }
        if (breathingProblem == true)
        {
            Breathing breathing = new Breathing();
            problemsList.Add(breathing);
        }
        if (armProblem == true)
        {
            BrokenArm arm = new BrokenArm();
            problemsList.Add(arm);
            boneArm.SetActive(true);
        }
        if (legProblem == true)
        {
            BrokenLeg leg = new BrokenLeg();
            problemsList.Add(leg);
            boneLeg.SetActive(true);
        }
        if (onbewust == true)
        {
            Onbewust bewust = new Onbewust();
            problemsList.Add(bewust);
            patientAnimator.SetTrigger("IsOnBewust");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5);
        foreach (var hit in hitColliders)
        {
            if (hit.name == "Player")
            {
                UnityEngine.Debug.Log("Hit");
                text.SetActive(true);
                InfoPatientAll.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    radialMenu.SetActive(true);

                    switch (gameObject.name)
                    {
                        case "patient-A":
                            TriageBackGroundA.SetActive(true);
                            break;

                        case "patient-B":
                            TriageBackGroundB.SetActive(true);
                            break;

                        case "patient-C":
                            TriageBackGroundC.SetActive(true);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                text.SetActive(false);
                InfoPatientAll.SetActive(false);
            }

            if (problemsList.Count==0)
            {
                isDone = true;
                isSaved = true;
                lifeTimer.Stop();
                text.GetComponent<Text>().text = "Patient is saved";
            }

            if (isSaved == false)
            {
                CheckTime();
            }

            if (warning == true && (Time.time >= timeWhenDisappear) && isDead == false)
            {
                warning = false;
                waiting = true;
                switch (gameObject.name)
                {
                    case "patient-A":
                        TriageBackGroundA.GetComponent<Image>().color = currentColorA;
                        TriageBackGroundA.GetComponentInChildren<Text>().color = Color.white;
                        break;

                    case "patient-B":
                        TriageBackGroundB.GetComponent<Image>().color = currentColorB;
                        TriageBackGroundB.GetComponentInChildren<Text>().color = Color.white;
                        break;

                    case "patient-C":
                        TriageBackGroundC.GetComponent<Image>().color = currentColorC;
                        TriageBackGroundC.GetComponentInChildren<Text>().color = Color.white;
                        break;

                    default:
                        break;
                }
            }

            if (warning == false && isDead == false)
            {
                currentColorA = TriageBackGroundA.GetComponent<Image>().color;
                currentColorB = TriageBackGroundB.GetComponent<Image>().color;
                currentColorC = TriageBackGroundC.GetComponent<Image>().color;

            }

            if (waiting == true)
            {
                timeToBlink = Time.time + timeToAppear;
            }

            if (waiting == true && (Time.time >= timeToBlink))
            {
                waiting = false;
            }
        }
    }

    public void StopTime()
    {
        lifeTimer.Stop();
    }

    public void StartTimer()
    {
        lifeTimer.Start();
    }

    public void RestartTimer()
    {
        lifeTimer.Restart();
    }

    public void CheckTime()
    {
        if (isDead == true)
        {
            lifeTimer.Stop();
            isDone = true;
            text.GetComponent<Text>().text = "Patient died";
        }
        if (isDead == false && isDone == true)
        {
            isSaved = true;
            text.GetComponent<Text>().text = "Patient is saved";
        }
        else
        {
            if (lifeTimer.ElapsedMilliseconds >= timeToLife)
            {
                isDead = true;
                isDone = true;
                lifeTimer.Stop();
                text.GetComponent<Text>().text = "Patient died";
                heartText.GetComponent<Text>().text = "0";
                heartVisuale.GetComponent<VideoPlayer>().clip = blackClip;
                InfoBewust.GetComponent<Image>().color = Color.red;
                InfoLung.GetComponent<Image>().color = Color.red;
                InfoLeg.GetComponent<Image>().color = Color.red;
                InfoArm.GetComponent<Image>().color = Color.red;
                InfoAirway.GetComponent<Image>().color = Color.red;
                switch (gameObject.name)
                {
                    case "patient-A":
                        TriageBackGroundA.GetComponent<Image>().color = Color.black;
                        break;

                    case "patient-B":
                        TriageBackGroundB.GetComponent<Image>().color = Color.black;
                        break;

                    case "patient-C":
                        TriageBackGroundC.GetComponent<Image>().color = Color.black;
                        break;

                    default:
                        break;
                }
            }

            if (lifeTimer.ElapsedMilliseconds >= timeToLife-60000 && isDead == false && warning == false && waiting == false)
            {
                warning = true;
                timeWhenDisappear = Time.time + timeToAppear;

                switch (gameObject.name)
                {
                    case "patient-A":
                        TriageBackGroundA.GetComponent<Image>().color = Color.white;
                        TriageBackGroundA.GetComponentInChildren<Text>().color = Color.red;
                        break;

                    case "patient-B":
                        TriageBackGroundB.GetComponent<Image>().color = Color.white;
                        TriageBackGroundB.GetComponentInChildren<Text>().color = Color.red;
                        break;

                    case "patient-C":
                        TriageBackGroundC.GetComponent<Image>().color = Color.white;
                        TriageBackGroundC.GetComponentInChildren<Text>().color = Color.red;
                        break;

                    default:
                        break;
                }
            }
        }
    }

    public void ShowHeart(string num)
    {
        heartText.GetComponent<Text>().text = num;
        heartText.SetActive(true);
    }

    public void ShowVisuale(bool problem)
    {
        if (problem==false)
        {
            heartVisuale.GetComponent<VideoPlayer>().clip = heartClip;
            heartVisuale.SetActive(true);
        }
        else
        {
            heartVisuale.SetActive(true);
        }
    }
}
