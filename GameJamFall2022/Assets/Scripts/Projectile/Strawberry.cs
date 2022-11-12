using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
    public float Velocity;

    void Start()
    {
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position).normalized * Velocity;
        Debug.Log($"DIRECTION: {dir}, MAGNITUDE: {dir.magnitude}");

        GetComponent<Rigidbody2D>().velocity = dir;
        transform.Rotate(new Vector3(0, 0, Vector3.Angle(new Vector2(1, 0), dir)));
        //transform.rotation = Quaternion.LookRotation(dir);
        transform.position = gameObject.transform.position;
    }
}
