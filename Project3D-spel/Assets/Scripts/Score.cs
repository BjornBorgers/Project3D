using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    int minute = 0;
    int second = 0;

    List<bool> listDead = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.Find("InfoKeeper");

        listDead.Add(info.GetComponent<InfoForScoreScene>().doneA);
        listDead.Add(info.GetComponent<InfoForScoreScene>().doneB);
        listDead.Add(info.GetComponent<InfoForScoreScene>().doneC);

        foreach (var item in listDead)
        {
            if (item==false)
            {
                count++;
            }
        }
        patientSaveText.GetComponent<Text>().text = count.ToString();
        patientDiedText.GetComponent<Text>().text = (3 - count).ToString();
        time = (int)info.GetComponent<InfoForScoreScene>().playTimer.ElapsedMilliseconds;

        do
        {
            time = time - 60000;
            minute++;
        } while (time - 60000 >= 0);

        do
        {
            time = time - 1000;
            second++;
        } while (time - 1000 >= 0);

        timeText.GetComponent<Text>().text = minute + ":" + second;

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

        if (time<= 300000 )
        {
            score += 150;
        }
        if (time <= 180000)
        {
            score += 200;
        }
        if (time <= 120000)
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
