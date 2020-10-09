using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public enum TraigeLevel
{
    Blue=0,
    Green=1,
    Yellow=2,
    Orange=3,
    Red=4,
    Black=5,
}

public class Gamemanager : MonoBehaviour
{
    //patient class has traige color and set the time they have to live
    public class Patient
    {
        protected TraigeLevel patientLevel;
        protected int timeToLife;
        protected bool isDead = false;
        protected bool isSaved = false;
        protected Stopwatch lifeTimer;

        public TraigeLevel PatientLevel { get => patientLevel; set => patientLevel = value; }
        public int TimeToLife { get => timeToLife; set => timeToLife = value; }
        public bool IsDead { get => isDead; set => isDead = value; }
        public bool IsSaved { get => isSaved; set => isSaved = value; }
        public Stopwatch LifeTimer { get => lifeTimer; set => lifeTimer = value; }

        public Patient(TraigeLevel NPatientLevel)
        {
            switch (NPatientLevel)
            {
                case TraigeLevel.Blue:
                    IsSaved = true;
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
                    IsDead = true;
                    timeToLife = 60000;
                    break;
                default:
                    break;
            }

            LifeTimer = new Stopwatch();
        }

        public void StartTimer()
        {
            LifeTimer.Start();
        }

        public void CheckTime()
        {
            if (IsDead==true||IsSaved==true)
            {
                LifeTimer.Stop();
            }
            else
            {
                if (LifeTimer.ElapsedMilliseconds>=TimeToLife)
                {
                    IsDead = true;
                    LifeTimer.Stop();
                }
            }
        }
    }

    List<Patient> patientList = new List<Patient>();
    // Start is called before the first frame update
    void Start()
    {
        /*List<int> triageColors = new List<int>();
        if (Random.Range(5,7)==5)
        {
            int min = 0;
            int max = 6;
            int triageA = 0;
            int triageB = 0;
            int triageC = 0;
            int triageD = 0;
            int triageE = 0;

            triageColors.Add(triageA);
            triageColors.Add(triageB);
            triageColors.Add(triageC);
            triageColors.Add(triageD);
            triageColors.Add(triageE);

            for (int i = 0; i < 5; i++)
            {
                triageColors[i] = Random.Range(min, max);
                if (triageColors[i]==0)
                {
                    min++;
                }
                if (triageColors[i] == 5)
                {
                    max--;
                }
            }

            Patient patientA = new Patient((TraigeLevel)triageA);
            Patient patientB = new Patient((TraigeLevel)triageB);
            Patient patientC = new Patient((TraigeLevel)triageC);
            Patient patientD = new Patient((TraigeLevel)triageD);
            Patient patientE = new Patient((TraigeLevel)triageE);

            patientList.Add(patientA);
            patientList.Add(patientB);
            patientList.Add(patientC);
            patientList.Add(patientD);
            patientList.Add(patientE);
        }
        else
        {
            int min = 0;
            int max = 6;
            int triageA = 0;
            int triageB = 0;
            int triageC = 0;
            int triageD = 0;
            int triageE = 0;
            int triageF = 0;

            triageColors.Add(triageA);
            triageColors.Add(triageB);
            triageColors.Add(triageC);
            triageColors.Add(triageD);
            triageColors.Add(triageE);
            triageColors.Add(triageF);

            for (int i = 0; i < 6; i++)
            {
                triageColors[i] = Random.Range(min, max);
                if (triageColors[i] == 0)
                {
                    min++;
                }
                if (triageColors[i] == 5)
                {
                    max--;
                }
            }

            Patient patientA = new Patient((TraigeLevel)triageA);
            Patient patientB = new Patient((TraigeLevel)triageB);
            Patient patientC = new Patient((TraigeLevel)triageC);
            Patient patientD = new Patient((TraigeLevel)triageD);
            Patient patientE = new Patient((TraigeLevel)triageE);
            Patient patientF = new Patient((TraigeLevel)triageF);

            patientList.Add(patientA);
            patientList.Add(patientB);
            patientList.Add(patientC);
            patientList.Add(patientD);
            patientList.Add(patientE);
            patientList.Add(patientF);

        }

        foreach (Patient patient in patientList)
        {
            patient.StartTimer();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (Patient patient in patientList)
        {
            patient.CheckTime();
        }*/
    }
}
