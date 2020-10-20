using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTriage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.AngleAxis(1, Vector3.up) * gameObject.transform.rotation;
    }
}
