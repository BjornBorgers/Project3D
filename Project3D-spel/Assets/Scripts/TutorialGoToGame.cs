using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialGoToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5);
        foreach (var hit in hitColliders)
        {
            if (hit.name == "Player")
            {
                SceneManager.LoadScene("TitleAnimated");
            }
        }
    }
}
