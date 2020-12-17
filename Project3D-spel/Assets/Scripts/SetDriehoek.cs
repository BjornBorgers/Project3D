using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDriehoek : MonoBehaviour
{
    public GameObject holdingDriehoek;
    public GameObject driehoekToActivate;
    public GameObject info;
    public GameObject setUpText;
    public bool setUp = false;
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
            if (hit.name == "Player" && setUp == false && holdingDriehoek.activeSelf == false)
            {
                setUpText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    driehoekToActivate.SetActive(true);
                    setUp = true;
                    info.GetComponent<InfoForScoreScene>().isSetUp = true;
                }
            }
            else
            {
                setUpText.SetActive(false);
            }
        }
    }
}
