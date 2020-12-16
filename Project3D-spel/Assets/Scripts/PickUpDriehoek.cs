using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDriehoek : MonoBehaviour
{
    public GameObject pickUpText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2);
        foreach (var hit in hitColliders)
        {
            if (hit.name == "Player")
            {
                pickUpText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    this.gameObject.SetActive(false);
                }
            }
            else
            {
                pickUpText.SetActive(false);
            }
        }
    }
}
