using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    GameObject patientA;
    public GameObject patientB;
    public GameObject patientC;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        patientA = GameObject.Find("/Patients/listPatientA/patient-A");
    }

    // Update is called once per frame
    void Update()
    {
        if (patientA.GetComponent<Patient>().isDone==true && patientB.GetComponent<Patient>().isDone && patientC.GetComponent<Patient>().isDone)
        {
            SceneManager.LoadScene("ExitScreen");
        }
    }
}
