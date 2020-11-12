using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNurse : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public float speed;
    bool Move1=true;
    bool Move2 = false;
   

    // Update is called once per frame
    void Update()
    {
        if (Move1==true)
        {
            MoveTo1();
        }
        if (Move2 == true)
        {
            MoveTo2();
        }
    }

    public void MoveTo1()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        if (gameObject.transform.position == target.position)
        {
            Move1 = false;
            Move2 = true;
            gameObject.transform.rotation = new Quaternion(0,180,0,0);
        }
    }

    public void MoveTo2()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
        if (gameObject.transform.position == target2.position)
        {
            Move1 = true;
            Move2 = false;
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
