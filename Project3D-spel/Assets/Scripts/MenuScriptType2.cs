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

    public Text onBewustText;
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
        Player.GetComponentInChildren<Animator>().ResetTrigger("Use bandage");
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
                                            Debug.Log("HitBewust");
                                            hasProblem = true;
                                        }
                                    }

                                    if (hasProblem == true)
                                    {
                                        onBewustText.text = "Patient is unconscious";
                                        onBewustText.enabled = true;
                                        timeWhenDisappear = Time.time + timeToAppear;
                                    }
                                    else
                                    {
                                        onBewustText.text = "Patient is conscious";
                                        onBewustText.enabled = true;
                                        timeWhenDisappear = Time.time + timeToAppear;
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
                                    }
                                    Debug.Log("hitPat");

                                    if (hasProblem == true)
                                    {
                                        Debug.Log("hitProb");
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
                    if (onBewustText.enabled)
                    {
                        onBewustText.enabled = false;
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


        if (onBewustText.enabled && (Time.time >= timeWhenDisappear))
        {
            onBewustText.enabled = false;
        }

    }
}
