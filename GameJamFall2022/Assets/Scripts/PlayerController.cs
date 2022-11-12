using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MaxVelocity = 3;
    public float Acceleration = .5f;
    public float Damping = 1;
    private Vector2 VelocityVector;

    void Start()
    {

    }

    void Update()
    {
        VelocityVector += 
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized
            * Time.deltaTime * Acceleration;

        //VelocityVector -= VelocityVector.normalized * Damping;
        if (VelocityVector.magnitude > MaxVelocity)
            VelocityVector *= (MaxVelocity / VelocityVector.magnitude);

        transform.Translate(VelocityVector);
    }
}