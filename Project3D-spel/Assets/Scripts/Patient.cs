using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

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

    public class PatientStat
    {
        protected TraigeLevel patientLevel;
        protected int timeToLife;
        protected bool isDead = false;
        protected bool isSaved = false;
        protected Stopwatch lifeTimer;
        protected List<IProblems> problemsList = new List<IProblems>();

        public TraigeLevel PatientLevel { get => patientLevel; set => patientLevel = value; }
        public int TimeToLife { get => timeToLife; set => timeToLife = value; }
        public bool IsDead { get => isDead; set => isDead = value; }
        public bool IsSaved { get => isSaved; set => isSaved = value; }
        public Stopwatch LifeTimer { get => lifeTimer; set => lifeTimer = value; }
        public List<IProblems> ProblemsList { get => problemsList; set => problemsList = value; }

        public PatientStat(TraigeLevel NPatientLevel)
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

        public void PauseTimer()
        {
            lifeTimer.Stop();

        }

        public void RestartTimer()
        {
            LifeTimer.Restart();
        }

        public void CheckTime()
        {
            if (IsDead == true || IsSaved == true)
            {
                LifeTimer.Stop();
            }
            else
            {
                if (LifeTimer.ElapsedMilliseconds >= TimeToLife)
                {
                    IsDead = true;
                    LifeTimer.Stop();
                }
            }
        }

        public void GiveProblem()
        {
            switch (Random.Range(0,2))
            {
                case 0:
                    Breathing breathing = new Breathing();
                    ProblemsList.Add(breathing);
                    break;

                case 1:
                    HeartStopped heart = new HeartStopped();
                    ProblemsList.Add(heart);
                    break;

                default:
                    break;
            }
        }
    }
    public PatientStat patient = new PatientStat(TraigeLevel.Green);
    // Start is called before the first frame update
    void Start()
    {
        patient.GiveProblem();
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5);
        foreach (var hit in hitColliders)
        {
            if (hit.name=="Player")
            {
                text.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    radialMenu.SetActive(true);
                }
            }
            else
            {
                text.SetActive(false);
            }
        }
    }
}
