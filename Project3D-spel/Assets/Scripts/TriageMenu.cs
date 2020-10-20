using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriageMenu : MonoBehaviour
{
    public Vector2 normalisedMousePosition;
    public float currentAngle;
    public int selection;
    private int previousSelection;
    public GameObject firstMenu;
    public GameObject Player;

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

    public GameObject[] menuItems;

    private MenuItemTriage menuItemSc;
    private MenuItemTriage previousMenuItemSc;
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

        selection = (int)(currentAngle / 51.4f);

        if (selection != previousSelection)
        {
            previousMenuItemSc = menuItems[previousSelection].GetComponent<MenuItemTriage>();
            previousMenuItemSc.Deselect();
            previousSelection = selection;

            menuItemSc = menuItems[selection].GetComponent<MenuItemTriage>();
            menuItemSc.Select();
        }

        if (Input.GetMouseButtonDown(0))
        {
            switch (selection)
            {
                case 0:
                    Collider[] hitColliders0 = Physics.OverlapSphere(Player.transform.position, 5);
                    foreach (var hit in hitColliders0)
                    {
                        Debug.Log("Hit-Color");
                        switch (hit.name)
                        {
                            case "patient-A":
                                TriadeBackGroundA.color = new Color(255,100,0);
                                TriadeWarningA.GetComponent<MeshRenderer>().material = MaterialOrange;
                                Debug.Log("Hit-Orange");
                                break;

                            case "patient-B":
                                TriadeBackGroundB.color = new Color(255, 100, 0);
                                TriadeWarningB.GetComponent<MeshRenderer>().material = MaterialOrange;
                                Debug.Log("Hit-Orange");
                                break;

                            case "patient-C":
                                TriadeBackGroundC.color = new Color(255, 100, 0);
                                TriadeWarningC.GetComponent<MeshRenderer>().material = MaterialOrange;
                                Debug.Log("Hit-Orange");
                                break;

                            default:
                                Debug.Log("Hit-Def");
                                break;
                        }
                    }
                    break;
                case 1:
                    Collider[] hitColliders1 = Physics.OverlapSphere(Player.transform.position, 5);
                    foreach (var hit in hitColliders1)
                    {
                        switch (hit.name)
                        {
                            case "patient-A":
                                TriadeBackGroundA.color = Color.yellow;
                                TriadeWarningA.GetComponent<MeshRenderer>().material = MaterialYellow;
                                break;

                            case "patient-B":
                                TriadeBackGroundB.color = Color.yellow;
                                TriadeWarningB.GetComponent<MeshRenderer>().material = MaterialYellow;
                                break;

                            case "patient-C":
                                TriadeBackGroundC.color = Color.yellow;
                                TriadeWarningC.GetComponent<MeshRenderer>().material = MaterialYellow;
                                break;

                            default:
                                break;
                        }
                    }
                    break;
                case 2:
                    Collider[] hitColliders2 = Physics.OverlapSphere(Player.transform.position, 5);
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
                    break;
                case 3:
                    Collider[] hitColliders3 = Physics.OverlapSphere(Player.transform.position, 5);
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
                    break;
                case 4:
                    firstMenu.SetActive(true);
                    gameObject.SetActive(false);
                    break;
                case 5:
                    Collider[] hitColliders5 = Physics.OverlapSphere(Player.transform.position, 5);
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
                    break;
                case 6:
                    Collider[] hitColliders6 = Physics.OverlapSphere(Player.transform.position, 5);
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
                    break;
                default:
                    break;
            }
        }
    }
}
