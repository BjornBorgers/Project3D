﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemScript : MonoBehaviour
{
    Color hoverColor = Color.cyan;
    Color baseColor=new Color(74,72,70);
    public Image backGround;
    public GameObject description;
    // Start is called before the first frame update
    void Start()
    {
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
