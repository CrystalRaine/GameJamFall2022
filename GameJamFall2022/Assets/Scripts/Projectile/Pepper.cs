using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepper : MonoBehaviour
{
    public float Velocity;

    void Start()
    {
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position);

        GetComponent<Rigidbody2D>().velocity = dir / dir.magnitude * Velocity;

        transform.Rotate(new Vector3(0, 0, Vector3.Angle(new Vector2(1, 0), dir)));

        transform.position = gameObject.transform.position;
    }
}
