using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    public GameObject patientSaveText;
    public GameObject patientDiedText;
    public GameObject timeText;
    public GameObject scoreText;

    GameObject info;
    int count=0;
    int score = 0;
    int time = 0;
    TimeSpan elapsed;

    List<bool> listDead = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.Find("InfoKeeper");

        if (info.GetComponent<InfoForScoreScene>().ASaved == true)
        {
            count++;
        }
        if (info.GetComponent<InfoForScoreScene>().BSaved == true)
        {
            count++;
        }
        if (info.GetComponent<InfoForScoreScene>().CSaved == true)
        {
            count++;
        }
        patientSaveText.GetComponent<Text>().text = count.ToString();
        patientDiedText.GetComponent<Text>().text = (3 - count).ToString();
        time = (int)info.GetComponent<InfoForScoreScene>().playTimer.ElapsedMilliseconds;
        elapsed = info.GetComponent<InfoForScoreScene>().playTimer.Elapsed;
        string tsOut = elapsed.ToString(@"m\:ss");
        timeText.GetComponent<Text>().text = tsOut;

        switch (count)
        {
            case 0:
                score = 0;
                break;

            case 1:
                score = 150;
                break;

            case 2:
                score = 300;
                break;

            case 3:
                score = 450;
                break;

            default:
                break;
        }

        if (time<= 360000)
        {
            score += 150;
        }
        if (time <= 240000)
        {
            score += 200;
        }
        if (time <= 180000)
        {
            score += 200;
        }

        scoreText.GetComponent<Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
