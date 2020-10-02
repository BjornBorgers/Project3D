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
