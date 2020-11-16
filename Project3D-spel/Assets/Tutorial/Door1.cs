using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Door1 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hey");
        
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("TitleScreen");


        }
    }
}
