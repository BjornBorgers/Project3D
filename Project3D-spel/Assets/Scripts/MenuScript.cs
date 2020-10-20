﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public Vector2 normalisedMousePosition;
    public float currentAngle;
    public int selection;
    private int previousSelection;

    public GameObject[] menuItems;
    public GameObject ToA;
    public GameObject ToB;
    public GameObject ToC;
    public GameObject ToD;
    public GameObject ToE;
    public GameObject ToI;
    public GameObject ToT;
    public GameObject player;
    public GameObject text;
    public GameObject crossHair;

    private MenuItemScript menuItemSc;
    private MenuItemScript previousMenuItemSc;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<CameraMouse>().enabled = !player.GetComponent<CameraMouse>().enabled;
        player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
        text.SetActive(false);
        crossHair.SetActive(false);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        text.SetActive(false);
        normalisedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        currentAngle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x) * Mathf.Rad2Deg;

        currentAngle = (currentAngle + 360) % 360;

        selection = (int)currentAngle / 45;

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
                    gameObject.SetActive(false);
                    ToB.SetActive(true);
                    break;
                case 1:
                    gameObject.SetActive(false);
                    ToA.SetActive(true);
                    break;
                case 2:
                    gameObject.SetActive(false);
                    ToI.SetActive(true);
                    break;
                case 3:
                    gameObject.SetActive(false);
                    ToT.SetActive(true);
                    break;
                case 4:
                    player.GetComponent<CameraMouse>().enabled = !player.GetComponent<CameraMouse>().enabled;
                    player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
                    Cursor.visible = false;
                    crossHair.SetActive(true);
                    gameObject.SetActive(false);
                    text.SetActive(true);
                    break;
                case 5:
                    gameObject.SetActive(false);
                    ToE.SetActive(true);
                    break;
                case 6:
                    gameObject.SetActive(false);
                    ToD.SetActive(true);
                    break;
                case 7:
                    gameObject.SetActive(false);
                    ToC.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}
