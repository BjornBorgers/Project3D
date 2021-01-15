using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public GameObject patientA;
    public GameObject patientB;
    public GameObject patientC;

    public List<GameObject> patientListA = new List<GameObject>();
    public List<GameObject> patientListB = new List<GameObject>();
    public List<GameObject> patientListC = new List<GameObject>();
    public GameObject infoKeeper;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        patientA = patientListA[Random.Range(0, patientListA.Count-1)];
        patientB = patientListB[Random.Range(0, patientListB.Count-1)];
        patientC = patientListC[Random.Range(0, patientListC.Count-1)];

        patientA.SetActive(true);
        patientB.SetActive(true);
        patientC.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (patientA.GetComponent<Patient>().isDone==true && patientB.GetComponent<Patient>().isDone && patientC.GetComponent<Patient>().isDone)
        {
            infoKeeper.GetComponent<InfoForScoreScene>().StopTimer();
            SceneManager.LoadScene("Scorescreen");
        }
    }
}
