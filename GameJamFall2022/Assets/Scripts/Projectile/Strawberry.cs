using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
    public float Velocity;

    void Start()
    {
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position).normalized * Velocity;
        GetComponent<Rigidbody2D>().velocity = dir;
        transform.Rotate(new Vector3(0, 0, Vector3.Angle(new Vector3(0, 1, 0), dir)));

        transform.position = gameObject.transform.position;
    }
}
