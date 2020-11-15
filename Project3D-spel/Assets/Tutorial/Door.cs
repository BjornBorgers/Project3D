using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject klink;
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
        if (collision.collider.gameObject.tag == "Player")
        {
            klink.SetActive(false);
            this.gameObject.SetActive(false);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hey");
        
        if (other.gameObject.tag == "Player")
        {
            klink.SetActive(false);
            this.gameObject.SetActive(false);
            Debug.Log("hey");
            
           
        }
    }
}
