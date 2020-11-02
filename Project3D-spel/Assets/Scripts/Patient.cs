using System.Collections;
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

    int timeToLife;
    bool isDead = false;
    bool isSaved = false;
    public bool isDone = false;
    public List<IProblems> problemsList = new List<IProblems>();


    // Start is called before the first frame update
    void Start()
    {
        switch (level)
        {
            case TraigeLevel.Blue:
                isSaved = true;
                timeToLife = 720000;
                break;
            case TraigeLevel.Green:
                timeToLife = 720000;
                break;
            case TraigeLevel.Yellow:
                timeToLife = 600000;
                break;
            case TraigeLevel.Orange:
                timeToLife = 480000;
                break;
            case TraigeLevel.Red:
                timeToLife = 300000;
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
            }

            CheckTime();
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
        if (isDead == true || isSaved == true)
        {
            lifeTimer.Stop();
            isDone = true;
        }
        else
        {
            if (lifeTimer.ElapsedMilliseconds >= timeToLife)
            {
                isDead = true;
                isDone = true;
                lifeTimer.Stop();
                ShowHeart("0");
                heartVisuale.GetComponent<VideoPlayer>().clip = blackClip;
                InfoBewust.GetComponent<Image>().color = Color.red;
                InfoLung.GetComponent<Image>().color = Color.red;
                InfoLeg.GetComponent<Image>().color = Color.red;
                InfoArm.GetComponent<Image>().color = Color.red;
                InfoAirway.GetComponent<Image>().color = Color.red;
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
