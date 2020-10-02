using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriageMenu : MonoBehaviour
{
    public Vector2 normalisedMousePosition;
    public float currentAngle;
    public int selection;
    private int previousSelection;
    public GameObject firstMenu;

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
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    firstMenu.SetActive(true);
                    gameObject.SetActive(false);
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                default:
                    break;
            }
        }
    }
}
