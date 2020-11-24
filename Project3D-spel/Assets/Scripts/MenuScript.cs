using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject ToA;
    public GameObject ToB;
    public GameObject ToC;
    public GameObject ToD;
    public GameObject ToE;
    public GameObject ToI;
    public GameObject ToT;
    public GameObject player;
    public GameObject text;
    public GameObject textMiddle;
    public GameObject crossHair;
    public GameObject verpleegster;


    public AudioClip heartClip;
    public AudioClip badBreathingClip;
    public AudioClip goodBreathingClip;

    public Image TriadeBackGroundA;
    public Image TriadeBackGroundB;
    public Image TriadeBackGroundC;
    public GameObject TriadeWarningA;
    public GameObject TriadeWarningB;
    public GameObject TriadeWarningC;
    public Material MaterialBlue;
    public Material MaterialGreen;
    public Material MaterialYellow;
    public Material MaterialOrange;
    public Material MaterialRed;
    public Material MaterialBlack;

    public Text analyseText;
    private float timeToAppear = 2f;
    private float timeWhenDisappear;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        text.SetActive(false);
        Cursor.visible = true;
        player.GetComponent<CameraMouse>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        crossHair.SetActive(false);

        if (analyseText.enabled && (Time.time >= timeWhenDisappear))
        {
            analyseText.enabled = false;
        }
    }

    //ToOpen
    public void OpenA()
    {
        ToA.SetActive(true);
        ToB.SetActive(false);
        ToC.SetActive(false);
        ToD.SetActive(false);
        ToE.SetActive(false);
        ToI.SetActive(false);
        ToT.SetActive(false);
    }

    public void OpenB()
    {
        ToA.SetActive(false);
        ToB.SetActive(true);
        ToC.SetActive(false);
        ToD.SetActive(false);
        ToE.SetActive(false);
        ToI.SetActive(false);
        ToT.SetActive(false);
    }

    public void OpenC()
    {
        ToA.SetActive(false);
        ToB.SetActive(false);
        ToC.SetActive(true);
        ToD.SetActive(false);
        ToE.SetActive(false);
        ToI.SetActive(false);
        ToT.SetActive(false);
    }

    public void OpenD()
    {
        ToA.SetActive(false);
        ToB.SetActive(false);
        ToC.SetActive(false);
        ToD.SetActive(true);
        ToE.SetActive(false);
        ToI.SetActive(false);
        ToT.SetActive(false);
    }

    public void OpenE()
    {
        ToA.SetActive(false);
        ToB.SetActive(false);
        ToC.SetActive(false);
        ToD.SetActive(false);
        ToE.SetActive(true);
        ToI.SetActive(false);
        ToT.SetActive(false);
    }

    public void OpenI()
    {
        ToA.SetActive(false);
        ToB.SetActive(false);
        ToC.SetActive(false);
        ToD.SetActive(false);
        ToE.SetActive(false);
        ToI.SetActive(true);
        ToT.SetActive(false);
    }

    public void OpenT()
    {
        ToA.SetActive(false);
        ToB.SetActive(false);
        ToC.SetActive(false);
        ToD.SetActive(false);
        ToE.SetActive(false);
        ToI.SetActive(false);
        ToT.SetActive(true);
    }

    //ToOpen
    //ToClose
    public void CloseMenu()
    {
        player.GetComponent<CameraMouse>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        Cursor.visible = false;
        crossHair.SetActive(true);
        gameObject.SetActive(false);
        text.SetActive(true);
        textMiddle.SetActive(false);
        ToA.SetActive(false);
        ToB.SetActive(false);
        ToC.SetActive(false);
        ToD.SetActive(false);
        ToE.SetActive(false);
        ToI.SetActive(false);
        ToT.SetActive(false);
    }
    //ToClose
    //Analyse
    public void AnalyseA()
    {
        Collider[] hitCollidersA = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitCollidersA)
        {
            if (hit.name.Contains("patient"))
            {
                if (hit.GetComponent<Patient>().isDone == false)
                {
                    analyseText.text = "Airway is free";
                    analyseText.enabled = true;
                    timeWhenDisappear = Time.time + timeToAppear;
                    hit.GetComponent<Patient>().InfoAirway.enabled = true;
                    hit.GetComponent<Patient>().InfoAirway.GetComponent<Image>().color = Color.green;
                }
            }
        }
    }

    public void AnalyseB()
    {
        Collider[] hitCollidersB = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitCollidersB)
        {
            if (hit.name.Contains("patient"))
            {
                bool hasProblem = false;
                List<IProblems> newList = hit.GetComponent<Patient>().problemsList;
                for (int i = 0; i < hit.GetComponent<Patient>().problemsList.Count; i++)
                {
                    if (hit.GetComponent<Patient>().problemsList[i].Name() == "breathing")
                    {
                        hasProblem = true;
                    }
                }

                if (hasProblem == true && hit.GetComponent<Patient>().isDone == false)
                {
                    hit.GetComponent<Patient>().GetComponent<AudioSource>().clip = badBreathingClip;
                    hit.GetComponent<Patient>().GetComponent<AudioSource>().Play();
                    hit.GetComponent<Patient>().InfoLung.enabled = true;
                    hit.GetComponent<Patient>().InfoLung.GetComponent<Image>().color = Color.red;
                }
                else if (hasProblem == false && hit.GetComponent<Patient>().isDone == false)
                {
                    hit.GetComponent<Patient>().GetComponent<AudioSource>().clip = goodBreathingClip;
                    hit.GetComponent<Patient>().GetComponent<AudioSource>().Play();
                    hit.GetComponent<Patient>().InfoLung.enabled = true;
                    hit.GetComponent<Patient>().InfoLung.GetComponent<Image>().color = Color.green;
                }
            }
        }
    }

    public void AnalyseC()
    {
        Collider[] hitCollidersC = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitCollidersC)
        {
            if (hit.name.Contains("patient"))
            {
                bool hasProblem = false;
                List<IProblems> newList = hit.GetComponent<Patient>().problemsList;
                for (int i = 0; i < hit.GetComponent<Patient>().problemsList.Count; i++)
                {
                    if (hit.GetComponent<Patient>().problemsList[i].Name() == "heart")
                    {
                        hasProblem = true;
                    }
                }

                if (hasProblem == false && hit.GetComponent<Patient>().isDone == false)
                {
                    hit.GetComponent<Patient>().GetComponent<AudioSource>().clip = heartClip;
                    hit.GetComponent<Patient>().GetComponent<AudioSource>().Play();
                    hit.GetComponent<Patient>().ShowHeart("80");
                    hit.GetComponent<Patient>().ShowVisuale(hasProblem);
                }
                else if (hasProblem == true && hit.GetComponent<Patient>().isDone == false)
                {
                    hit.GetComponent<Patient>().ShowHeart("0");
                    hit.GetComponent<Patient>().ShowVisuale(hasProblem);
                }
            }
        }
    }

    public void AnalyseD()
    {
        Collider[] hitCollidersD = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitCollidersD)
        {
            if (hit.name.Contains("patient"))
            {
                bool hasProblem = false;
                List<IProblems> newList = hit.GetComponent<Patient>().problemsList;
                for (int i = 0; i < hit.GetComponent<Patient>().problemsList.Count; i++)
                {
                    if (hit.GetComponent<Patient>().problemsList[i].Name() == "bewust")
                    {
                        hasProblem = true;
                    }
                }

                if (hasProblem == true && hit.GetComponent<Patient>().isDone == false)
                {
                    analyseText.text = "Patient is unconscious and is unresponsive";
                    analyseText.enabled = true;
                    timeWhenDisappear = Time.time + timeToAppear;
                    hit.GetComponent<Patient>().InfoBewust.enabled = true;
                    hit.GetComponent<Patient>().InfoBewust.GetComponent<Image>().color = Color.red;
                }
                else if (hasProblem == false && hit.GetComponent<Patient>().isDone == false)
                {
                    analyseText.text = "Patient is conscious";
                    analyseText.enabled = true;
                    timeWhenDisappear = Time.time + timeToAppear;
                    hit.GetComponent<Patient>().InfoBewust.enabled = true;
                    hit.GetComponent<Patient>().InfoBewust.GetComponent<Image>().color = Color.green;
                }
            }
        }
    }

    public void AnalyseE()
    {
        Collider[] hitCollidersE = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitCollidersE)
        {
            if (hit.name.Contains("patient"))
            {
                bool hasLegProblem = false;
                bool hasArmProblem = false;
                List<IProblems> newList = hit.GetComponent<Patient>().problemsList;
                for (int i = 0; i < hit.GetComponent<Patient>().problemsList.Count; i++)
                {
                    if (hit.GetComponent<Patient>().problemsList[i].Name() == "leg")
                    {
                        hasLegProblem = true;
                    }
                    if (hit.GetComponent<Patient>().problemsList[i].Name() == "arm")
                    {
                        hasArmProblem = true;
                    }

                }

                if (hasArmProblem == true && hasLegProblem == true && hit.GetComponent<Patient>().isDone == false)
                {
                    Debug.Log("Here");
                    analyseText.text = "Patient has a broken leg and arm";
                    analyseText.enabled = true;
                    timeWhenDisappear = Time.time + timeToAppear;
                    hit.GetComponent<Patient>().InfoArm.enabled = true;
                    hit.GetComponent<Patient>().InfoArm.GetComponent<Image>().color = Color.red;
                    hit.GetComponent<Patient>().InfoLeg.enabled = true;
                    hit.GetComponent<Patient>().InfoLeg.GetComponent<Image>().color = Color.red;
                }
                else if (hit.GetComponent<Patient>().isDone == false)
                {
                    hit.GetComponent<Patient>().InfoArm.enabled = true;
                    hit.GetComponent<Patient>().InfoArm.GetComponent<Image>().color = Color.green;
                    hit.GetComponent<Patient>().InfoLeg.enabled = true;
                    hit.GetComponent<Patient>().InfoLeg.GetComponent<Image>().color = Color.green;
                    if (hasLegProblem == true)
                    {
                        analyseText.text = "Patient has a broken leg";
                        analyseText.enabled = true;
                        timeWhenDisappear = Time.time + timeToAppear;
                        hit.GetComponent<Patient>().InfoLeg.GetComponent<Image>().color = Color.red;
                    }
                    if (hasArmProblem == true)
                    {
                        analyseText.text = "Patient has a broken arm";
                        analyseText.enabled = true;
                        timeWhenDisappear = Time.time + timeToAppear;
                        hit.GetComponent<Patient>().InfoArm.GetComponent<Image>().color = Color.red;
                    }
                }
            }
        }
    }
    //Analyse
    //UseItem
    public void UseBandage()
    {
        Collider[] hitCollidersI = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitCollidersI)
        {
            if (hit.name.Contains("patient"))
            {
                bool hasProblem = false;
                List<IProblems> newList = hit.GetComponent<Patient>().problemsList;
                for (int i = 0; i < hit.GetComponent<Patient>().problemsList.Count; i++)
                {
                    if (hit.GetComponent<Patient>().problemsList[i].Name() == "leg" || hit.GetComponent<Patient>().problemsList[i].Name() == "arm" && hit.GetComponent<Patient>().isDone == false)
                    {
                        hasProblem = true;
                    }
                    if (hit.GetComponent<Patient>().problemsList[i].Name() == "leg" && hit.GetComponent<Patient>().isDone == false)
                    {
                        hit.GetComponent<Patient>().problemsList.Remove(hit.GetComponent<Patient>().problemsList[i]);
                        hit.GetComponent<Patient>().boneLeg.SetActive(false);
                        hit.GetComponent<Patient>().legSpaak.SetActive(true);
                        hit.GetComponent<Patient>().bindingSpaak.SetActive(true);
                        hit.GetComponent<Patient>().InfoLeg.GetComponent<Image>().color = Color.green;
                    }
                    if (hit.GetComponent<Patient>().problemsList[i].Name() == "arm" && hit.GetComponent<Patient>().isDone == false)
                    {
                        hit.GetComponent<Patient>().problemsList.Remove(hit.GetComponent<Patient>().problemsList[i]);
                        hit.GetComponent<Patient>().boneArm.SetActive(false);
                        hit.GetComponent<Patient>().armSpaak.SetActive(true);
                        hit.GetComponent<Patient>().InfoArm.GetComponent<Image>().color = Color.green;
                    }
                }
            }
        }
    }
    //UseItem
    //Treatment
    public void TreatB()
    {
        Collider[] hitCollidersB = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitCollidersB)
        {
            if (hit.name.Contains("patient"))
            {
                bool hasProblem = false;
                List<IProblems> newList = hit.GetComponent<Patient>().problemsList;
                for (int i = 0; i < hit.GetComponent<Patient>().problemsList.Count; i++)
                {
                    if (hit.GetComponent<Patient>().problemsList[i].Name() == "breathing")
                    {
                        hasProblem = true;
                        hit.GetComponent<Patient>().problemsList.Remove(hit.GetComponent<Patient>().problemsList[i]);
                    }
                }

                if (hasProblem == true && hit.GetComponent<Patient>().isDone == false)
                {
                    hit.GetComponent<Patient>().InfoLung.GetComponent<Image>().color = Color.green;
                }
            }
        }
    }

    public void TreatC()
    {
        Collider[] hitCollidersC = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitCollidersC)
        {
            if (hit.name.Contains("patient"))
            {
                bool hasProblem = false;
                List<IProblems> newList = hit.GetComponent<Patient>().problemsList;
                for (int i = 0; i < hit.GetComponent<Patient>().problemsList.Count; i++)
                {
                    if (hit.GetComponent<Patient>().problemsList[i].Name() == "heart")
                    {
                        hasProblem = true;
                        hit.GetComponent<Patient>().problemsList.Remove(hit.GetComponent<Patient>().problemsList[i]);
                    }
                }

                if (hasProblem == true && hit.GetComponent<Patient>().isDone == false)
                {
                    hit.GetComponent<Patient>().ShowHeart("80");
                    hit.GetComponent<Patient>().ShowVisuale(false);
                    player.GetComponentInChildren<Animator>().SetTrigger("Use Beademing");
                    hit.GetComponent<Patient>().GetComponent<Animator>().SetTrigger("StartHeart");

                }
            }
        }
    }

    public void TreatD()
    {
        Collider[] hitCollidersD = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitCollidersD)
        {
            if (hit.name.Contains("patient"))
            {
                bool hasProblem = false;
                List<IProblems> newList = hit.GetComponent<Patient>().problemsList;
                for (int i = 0; i < hit.GetComponent<Patient>().problemsList.Count; i++)
                {
                    if (hit.GetComponent<Patient>().problemsList[i].Name() == "bewust")
                    {
                        hasProblem = true;
                        hit.GetComponent<Patient>().problemsList.Remove(hit.GetComponent<Patient>().problemsList[i]);
                    }
                }

                if (hasProblem == true && hit.GetComponent<Patient>().isDone == false)
                {
                    switch (hit.name)
                    {
                        case "patient-A":
                            verpleegster.transform.position = new Vector3(-126, 0.3f, 7f);
                            verpleegster.transform.rotation = new Quaternion(0, 90, 0, 0);
                            break;

                        case "patient-B":
                            verpleegster.transform.position = new Vector3(-132, 0.3f, 29f);
                            verpleegster.transform.rotation = new Quaternion(0, 180, 0, 0);
                            break;

                        case "patient-C":
                            verpleegster.transform.position = new Vector3(-116, 0.3f, -8.5f);
                            verpleegster.transform.rotation = new Quaternion(0, 180, 0, 0);
                            break;

                        default:
                            break;
                    }
                    hit.GetComponent<Patient>().InfoBewust.color = Color.green;
                    verpleegster.GetComponent<Animator>().SetTrigger("StartZit");
                    verpleegster.GetComponent<MoveNurse>().enabled = false;
                }
            }
        }
    }

    public void TreatE()
    {

    }
    //Treatment
    //TriageColors
    public void TriageBL()
    {
        Collider[] hitColliders5 = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitColliders5)
        {
            switch (hit.name)
            {
                case "patient-A":
                    TriadeBackGroundA.color = Color.blue;
                    TriadeWarningA.GetComponent<MeshRenderer>().material = MaterialBlue;
                    break;

                case "patient-B":
                    TriadeBackGroundB.color = Color.blue;
                    TriadeWarningB.GetComponent<MeshRenderer>().material = MaterialBlue;
                    break;

                case "patient-C":
                    TriadeBackGroundC.color = Color.blue;
                    TriadeWarningC.GetComponent<MeshRenderer>().material = MaterialBlue;
                    break;

                default:
                    break;
            }
        }
    }

    public void TriageGR()
    {
        Collider[] hitColliders6 = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitColliders6)
        {
            switch (hit.name)
            {
                case "patient-A":
                    TriadeBackGroundA.color = Color.green;
                    TriadeWarningA.GetComponent<MeshRenderer>().material = MaterialGreen;
                    break;

                case "patient-B":
                    TriadeBackGroundB.color = Color.green;
                    TriadeWarningB.GetComponent<MeshRenderer>().material = MaterialGreen;
                    break;

                case "patient-C":
                    TriadeBackGroundC.color = Color.green;
                    TriadeWarningC.GetComponent<MeshRenderer>().material = MaterialGreen;
                    break;

                default:
                    break;
            }
        }
    }

    public void TriageYE()
    {
        Collider[] hitColliders1 = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitColliders1)
        {
            switch (hit.name)
            {
                case "patient-A":
                    TriadeBackGroundA.color = new Color(255, 100, 0);
                    TriadeWarningA.GetComponent<MeshRenderer>().material = MaterialYellow;
                    break;

                case "patient-B":
                    TriadeBackGroundA.color = new Color(255, 100, 0);
                    TriadeWarningB.GetComponent<MeshRenderer>().material = MaterialYellow;
                    break;

                case "patient-C":
                    TriadeBackGroundA.color = new Color(255, 100, 0);
                    TriadeWarningC.GetComponent<MeshRenderer>().material = MaterialYellow;
                    break;

                default:
                    break;
            }
        }
    }

    public void TriageOR()
    {
        Collider[] hitColliders0 = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitColliders0)
        {
            Debug.Log("Hit-Color");
            switch (hit.name)
            {
                case "patient-A":
                    TriadeBackGroundA.color = Color.yellow;
                    TriadeWarningA.GetComponent<MeshRenderer>().material = MaterialOrange;
                    break;

                case "patient-B":
                    TriadeBackGroundA.color = Color.yellow;
                    TriadeWarningB.GetComponent<MeshRenderer>().material = MaterialOrange;
                    break;

                case "patient-C":
                    TriadeBackGroundA.color = Color.yellow;
                    TriadeWarningC.GetComponent<MeshRenderer>().material = MaterialOrange;
                    break;

                default:
                    Debug.Log("Hit-Def");
                    break;
            }
        }
    }

    public void TriageRE()
    {
        Collider[] hitColliders2 = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitColliders2)
        {
            switch (hit.name)
            {
                case "patient-A":
                    TriadeBackGroundA.color = Color.red;
                    TriadeWarningA.GetComponent<MeshRenderer>().material = MaterialRed;
                    break;

                case "patient-B":
                    TriadeBackGroundB.color = Color.red;
                    TriadeWarningB.GetComponent<MeshRenderer>().material = MaterialRed;
                    break;

                case "patient-C":
                    TriadeBackGroundC.color = Color.red;
                    TriadeWarningC.GetComponent<MeshRenderer>().material = MaterialRed;
                    break;

                default:
                    break;
            }
        }
    }

    public void TriageBLA()
    {
        Collider[] hitColliders3 = Physics.OverlapSphere(player.transform.position, 5);
        foreach (var hit in hitColliders3)
        {
            switch (hit.name)
            {
                case "patient-A":
                    TriadeBackGroundA.color = Color.black;
                    TriadeWarningA.GetComponent<MeshRenderer>().material = MaterialBlack;
                    break;

                case "patient-B":
                    TriadeBackGroundB.color = Color.black;
                    TriadeWarningB.GetComponent<MeshRenderer>().material = MaterialBlack;
                    break;

                case "patient-C":
                    TriadeBackGroundC.color = Color.black;
                    TriadeWarningC.GetComponent<MeshRenderer>().material = MaterialBlack;
                    break;

                default:
                    break;
            }
        }
    }
    //TriageColors
}
