using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePatients : MonoBehaviour
{
    public List<GameObject> patientListA = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        patientListA[Random.Range(0, patientListA.Count)].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
