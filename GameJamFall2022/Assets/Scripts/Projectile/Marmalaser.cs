using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marmalaser : MonoBehaviour
{
    public GameObject laser;
    public GameObject laserSplash;


    // Start is called before the first frame update
    void Start()
    {
        GameObject inst = GameObject.Instantiate(laser);
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position);
        inst.transform.Rotate(new Vector3(0, 0, Vector3.Angle(new Vector3(0, 1, 0), dir)));


    }
}
