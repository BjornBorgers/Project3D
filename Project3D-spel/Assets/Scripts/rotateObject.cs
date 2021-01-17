using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour
{
    public int rotatingSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotatingSpeed, 0, Space.World);
    }
}
