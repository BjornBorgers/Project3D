using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouse : MonoBehaviour
{
    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;

    void Update()
    {
        Look();
    }

    public void Look() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");

        //Restrict up/down camera movement
        rotation.x = Mathf.Clamp(rotation.x, -10f, 10f);
        this.gameObject.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, rotation.y * lookSpeed, 0);
    }
}
