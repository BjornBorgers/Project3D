using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextTutorial : MonoBehaviour
{
    public GameObject textTutorial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3);
        foreach (var hit in hitColliders)
        {
            if (hit.name == "Player")
            {
                textTutorial.SetActive(true);
            }
            else
            {
                textTutorial.SetActive(false);
            }
        } 
    }
}
