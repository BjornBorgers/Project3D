using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScriptType2 : MonoBehaviour
{
    public Vector2 normalisedMousePosition;
    public float currentAngle;
    public int selection;
    private int previousSelection;
    public GameObject firstMenu;

    public GameObject[] menuItems;

    public GameObject Player;

    public AudioClip heartClip;
    public AudioClip badBreathingClip;
    public AudioClip goodBreathingClip;

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
        if (Input.GetMouseButtonDown(0))
        {
            switch (selection)
            {
                case 0:
                    switch (gameObject.name)
                    {
                        case "RadialmenuB":
                            Collider[] hitCollidersB = Physics.OverlapSphere(Player.transform.position, 5);
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

                                    if (hasProblem==true && hit.GetComponent<Patient>().isDone == false)
                                    {
                                        hit.GetComponent<Patient>().GetComponent<AudioSource>().clip= badBreathingClip;
                                        hit.GetComponent<Patient>().GetComponent<AudioSource>().Play();
                                        hit.GetComponent<Patient>().InfoLung.enabled=true;
                                        hit.GetComponent<Patient>().InfoLung.GetComponent<Image>().color= Color.red;
                                    }
                                    else if(hasProblem == false && hit.GetComponent<Patient>().isDone == false)
                                    {
                                        hit.GetComponent<Patient>().GetComponent<AudioSource>().clip = goodBreathingClip;
                                        hit.GetComponent<Patient>().GetComponent<AudioSource>().Play();
                                        hit.GetComponent<Patient>().InfoLung.enabled = true;
                                        hit.GetComponent<Patient>().InfoLung.GetComponent<Image>().color = Color.green;
                                    }
                                }
                            }
                                break;

                        case "RadialmenuC":
                            Collider[] hitCollidersC = Physics.OverlapSphere(Player.transform.position, 5);
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

                                    if (hasProblem == false /*&& hit.GetComponent<Patient>().isDone == false*/)
                                    {
                                        hit.GetComponent<Patient>().GetComponent<AudioSource>().clip = heartClip;
                                        hit.GetComponent<Patient>().GetComponent<AudioSource>().Play();
                                        hit.GetComponent<Patient>().ShowHeart("80");
                                        hit.GetComponent<Patient>().ShowVisuale(hasProblem);
                                    }
                                    else if (hasProblem == true /*&& hit.GetComponent<Patient>().isDone == false*/)
                                    {
                                        hit.GetComponent<Patient>().ShowHeart("0");
                                        hit.GetComponent<Patient>().ShowVisuale(hasProblem);
                                    }
                                }
                            }
                            break;

                        case "RadialmenuD":
                            Collider[] hitCollidersD = Physics.OverlapSphere(Player.transform.position, 5);
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
                            break;

                        case "RadialmenuE":
                            Collider[] hitCollidersE = Physics.OverlapSphere(Player.transform.position, 5);
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

                                    if (hasArmProblem==true&&hasLegProblem==true && hit.GetComponent<Patient>().isDone == false)
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
                            break;

                        case "RadialmenuI":
                            Collider[] hitCollidersI = Physics.OverlapSphere(Player.transform.position, 5);
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
                                            hit.GetComponent<Patient>().InfoLeg.GetComponent<Image>().color = Color.green;
                                        }
                                        if (hit.GetComponent<Patient>().problemsList[i].Name() == "arm" && hit.GetComponent<Patient>().isDone == false)
                                        {
                                            hit.GetComponent<Patient>().problemsList.Remove(hit.GetComponent<Patient>().problemsList[i]);
                                            hit.GetComponent<Patient>().boneArm.SetActive(false);
                                            hit.GetComponent<Patient>().InfoArm.GetComponent<Image>().color = Color.green;
                                        }
                                    }

                                    if (hasProblem == true && hit.GetComponent<Patient>().isDone == false)
                                    {
                                        Player.GetComponentInChildren<Animator>().SetTrigger("Use bandage");
                                    }
                                }
                            }
                            break;

                        default:
                            break;
                    }
                    break;
                case 1:
                    firstMenu.SetActive(true);
                    gameObject.SetActive(false);
                    if (analyseText.enabled)
                    {
                        analyseText.enabled = false;
                    }
                    break;
                case 2:
                    switch (gameObject.name)
                    {
                        case "RadialmenuB":
                            Collider[] hitCollidersB = Physics.OverlapSphere(Player.transform.position, 5);
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
                            break;

                        case "RadialmenuC":
                            Collider[] hitCollidersC = Physics.OverlapSphere(Player.transform.position, 5);
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
                                        Player.GetComponentInChildren<Animator>().SetTrigger("Use Beademing");
                                    }
                                }
                            }
                            break;

                        case "RadialmenuD":
                            Collider[] hitCollidersD = Physics.OverlapSphere(Player.transform.position, 5);
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
                                    }
                                    else
                                    {
                                    }
                                }
                            }
                            break;

                        case "RadialmenuI":
                            Collider[] hitCollidersI = Physics.OverlapSphere(Player.transform.position, 5);
                            foreach (var hit in hitCollidersI)
                            {
                                if (hit.name.Contains("patient"))
                                {
                                }
                            }
                            break;

                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }


        if (analyseText.enabled && (Time.time >= timeWhenDisappear))
        {
            analyseText.enabled = false;
        }
    }
}
