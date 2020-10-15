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
                            case "patient":
                                TriadeBackGroundA.color = new Color(255,100,0);
                                Debug.Log("Hit-Orange");
                                break;

                            case "patient(1)":
                                TriadeBackGroundB.color = new Color(255, 100, 0);
                                Debug.Log("Hit-Orange");
                                break;

                            case "patient(2)":
                                TriadeBackGroundC.color = new Color(255, 100, 0);
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
                            case "patient":
                                TriadeBackGroundA.color = Color.yellow;
                                break;

                            case "patient(1)":
                                TriadeBackGroundB.color = Color.yellow;
                                break;

                            case "patient(2)":
                                TriadeBackGroundC.color = Color.yellow;
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
                            case "patient":
                                TriadeBackGroundA.color = Color.red;
                                break;

                            case "patient(1)":
                                TriadeBackGroundB.color = Color.red;
                                break;

                            case "patient(2)":
                                TriadeBackGroundC.color = Color.red;
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
                            case "patient":
                                TriadeBackGroundA.color = Color.black;
                                break;

                            case "patient(1)":
                                TriadeBackGroundB.color = Color.black;
                                break;

                            case "patient(2)":
                                TriadeBackGroundC.color = Color.black;
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
                            case "patient":
                                TriadeBackGroundA.color = Color.blue;
                                break;

                            case "patient(1)":
                                TriadeBackGroundB.color = Color.blue;
                                break;

                            case "patient(2)":
                                TriadeBackGroundC.color = Color.blue;
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
                            case "patient":
                                TriadeBackGroundA.color = Color.green;
                                break;

                            case "patient(1)":
                                TriadeBackGroundB.color = Color.green;
                                break;

                            case "patient(2)":
                                TriadeBackGroundC.color = Color.green;
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
