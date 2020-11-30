﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject hudScreen;
    public GameObject player;
    public GameObject infoTimer;
    // Start is called before the first frame update
    void Update()
    {
        infoTimer.GetComponent<InfoForScoreScene>().StopTimer();
        Cursor.visible = true;
        hudScreen.SetActive(false);
        player.GetComponent<CameraMouse>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    // Update is called once per frame
    public void Quit()
    {
        SceneManager.LoadScene("TitleAnimated");
    }

    public void Continue()
    {
        infoTimer.GetComponent<InfoForScoreScene>().UnpauzeTimer();
        gameObject.SetActive(false);
        hudScreen.SetActive(true);
        Cursor.visible = false;
        player.GetComponent<CameraMouse>().enabled = !player.GetComponent<CameraMouse>().enabled;
        player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
    }
}
