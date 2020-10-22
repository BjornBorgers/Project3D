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

    private MenuItemScript menuItemSc;
    private MenuItemScript previousMenuItemSc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        normalisedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        currentAngle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x) * Mathf.Rad2Deg;

        currentAngle = (currentAngle + 360) % 360;

        selection = (int)currentAngle / 120;

        if (selection != previousSelection)
        {
            previousMenuItemSc = menuItems[previousSelection].GetComponent<MenuItemScript>();
            previousMenuItemSc.Deselect();
            previousSelection = selection;

            menuItemSc = menuItems[selection].GetComponent<MenuItemScript>();
            menuItemSc.Select();
        }

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

                                    if (hasProblem==true)
                                    {
                                        hit.GetComponent<Patient>().GetComponent<AudioSource>().clip= badBreathingClip;
                                        hit.GetComponent<Patient>().GetComponent<AudioSource>().Play();
                                    }
                                    else
                                    {
                                        hit.GetComponent<Patient>().GetComponent<AudioSource>().clip = goodBreathingClip;
                                        hit.GetComponent<Patient>().GetComponent<AudioSource>().Play();
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

                                    if (hasProblem == false)
                                    {
                                        hit.GetComponent<Patient>().GetComponent<AudioSource>().clip = heartClip;
                                        hit.GetComponent<Patient>().GetComponent<AudioSource>().Play();
                                        hit.GetComponent<Patient>().ShowHeart("80");
                                        hit.GetComponent<Patient>().ShowVisuale(hasProblem);
                                    }
                                    else
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

                                    if (hasProblem == true)
                                    {
                                        analyseText.text = "Patient is unconscious";
                                        analyseText.enabled = true;
                                        timeWhenDisappear = Time.time + timeToAppear;
                                    }
                                    else
                                    {
                                        analyseText.text = "Patient is conscious";
                                        analyseText.enabled = true;
                                        timeWhenDisappear = Time.time + timeToAppear;
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

                                    if (hasArmProblem==true&&hasLegProblem==true)
                                    {
                                        Debug.Log("Here");
                                        analyseText.text = "Patient has a broken leg and arm";
                                        analyseText.enabled = true;
                                        timeWhenDisappear = Time.time + timeToAppear;
                                    }
                                    else
                                    {
                                        if (hasLegProblem == true)
                                        {
                                            analyseText.text = "Patient has a broken leg";
                                            analyseText.enabled = true;
                                            timeWhenDisappear = Time.time + timeToAppear;
                                        }
                                        if (hasArmProblem)
                                        {
                                            analyseText.text = "Patient has a broken arm";
                                            analyseText.enabled = true;
                                            timeWhenDisappear = Time.time + timeToAppear;
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
                                        if (hit.GetComponent<Patient>().problemsList[i].Name() == "leg" || hit.GetComponent<Patient>().problemsList[i].Name() == "arm")
                                        {
                                            hasProblem = true;
                                        }
                                        if (hit.GetComponent<Patient>().problemsList[i].Name() == "leg")
                                        {
                                            hit.GetComponent<Patient>().problemsList.Remove(hit.GetComponent<Patient>().problemsList[i]);
                                            hit.GetComponent<Patient>().boneLeg.SetActive(false);
                                        }
                                        if (hit.GetComponent<Patient>().problemsList[i].Name() == "arm")
                                        {
                                            hit.GetComponent<Patient>().problemsList.Remove(hit.GetComponent<Patient>().problemsList[i]);
                                            hit.GetComponent<Patient>().boneArm.SetActive(false);
                                        }
                                    }

                                    if (hasProblem == true)
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
                                        }
                                    }

                                    if (hasProblem == true)
                                    {
                                    }
                                    else
                                    { 
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

                                    if (hasProblem == true)
                                    {
                                        hit.GetComponent<Patient>().ShowHeart("80");
                                        hit.GetComponent<Patient>().ShowVisuale(false);
                                        Player.GetComponentInChildren<Animator>().SetTrigger("Use CPR");
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

                                    if (hasProblem == true)
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
