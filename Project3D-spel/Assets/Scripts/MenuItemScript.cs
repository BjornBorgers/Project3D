using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemScript : MonoBehaviour
{
    Color hoverColor = new Color(0,125,255);
    Color baseColor=new Color(74,72,70);
    public Image backGround;
    // Start is called before the first frame update
    void Start()
    {
        backGround.color = baseColor;
    }

    public void Select()
    {
        backGround.color = hoverColor;
    }

    public void Deselect()
    {
        backGround.color = baseColor;
    }
}
