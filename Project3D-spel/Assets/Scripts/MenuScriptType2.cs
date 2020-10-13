using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScriptType2 : MonoBehaviour
{
    public Vector2 normalisedMousePosition;
    public float currentAngle;
    public int selection;
    private int previousSelection;
    public GameObject firstMenu;

    public GameObject[] menuItems;

    public GameObject Player;

    public GameObject patientAudio;

    public AudioClip heartClip;
    public AudioClip badBreathingClip;
    public AudioClip goodBreathingClip;

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
                                    List<IProblems> newList = hit.GetComponent<Patient>().patient.ProblemsList;
                                    for (int i = 0; i < hit.GetComponent<Patient>().patient.ProblemsList.Count; i++)
                                    {
                                        if (hit.GetComponent<Patient>().patient.ProblemsList[i].Name() == "breathing")
                                        {
                                            hasProblem = true;
                                        }
                                    }

                                    if (hasProblem==true)
                                    {
                                        patientAudio.GetComponent<AudioSource>().clip=badBreathingClip;
                                        patientAudio.GetComponent<AudioSource>().Play();
                                    }
                                    else
                                    {
                                        patientAudio.GetComponent<AudioSource>().clip = goodBreathingClip;
                                         patientAudio.GetComponent<AudioSource>().Play();
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
                                    List<IProblems> newList = hit.GetComponent<Patient>().patient.ProblemsList;
                                    for (int i = 0; i < hit.GetComponent<Patient>().patient.ProblemsList.Count; i++)
                                    {
                                        if (hit.GetComponent<Patient>().patient.ProblemsList[i].Name() == "Heart")
                                        {
                                            hasProblem = true;
                                        }
                                    }

                                    if (hasProblem == true)
                                    {
                                        patientAudio.GetComponent<AudioSource>().clip = heartClip;
                                        patientAudio.GetComponent<AudioSource>().Play();
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
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}
