using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemTriage : MonoBehaviour
{
    Color hoverColor = Color.white;
    public int colorNum;
    Color baseColor = Color.gray;
    public Image backGround;
    public GameObject description;
    // Start is called before the first frame update
    void Start()
    {
        switch (colorNum)
        {
            case 0:
                baseColor = Color.gray;
                break;
            case 1:
                baseColor = Color.blue;
                break;
            case 2:
                baseColor = Color.green;
                break;
            case 3:
                baseColor = Color.yellow;
                break;
            case 4:
                baseColor = new Color(255,165,0);
                break;
            case 5:
                baseColor = Color.red;
                break;
            case 6:
                baseColor = Color.black;
                break;
            default:
                break;
        }
        backGround.color = baseColor;
    }

    public void Select()
    {
        backGround.color = hoverColor;
        description.SetActive(true);
    }

    public void Deselect()
    {
        backGround.color = baseColor;
        description.SetActive(false);
    }
}
