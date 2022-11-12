using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MaxVelocity = 3;
    public float Acceleration = .5f;
    public float Damping = 1;
    private Vector2 VelocityVector;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            sprite.flipX = false;
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            sprite.flipX = true;
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        var mag = VelocityVector.magnitude * (1 - Damping * Time.deltaTime);

        if (mag > 0)
            VelocityVector = VelocityVector.normalized * mag;
        else
            VelocityVector = Vector2.zero;

        var accelerationVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized
            * Time.deltaTime * Acceleration;

        VelocityVector += accelerationVector;

        if(VelocityVector.magnitude >= MaxVelocity) // if above max velocity
        {
            VelocityVector.Normalize();             // set velocity to max velocity
            VelocityVector *= MaxVelocity;
        }

        transform.Translate(VelocityVector * Time.deltaTime);
        VelocityVector += 
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized
            * Time.deltaTime * Acceleration;

        //VelocityVector -= VelocityVector.normalized * Damping;
        if (VelocityVector.magnitude > MaxVelocity)
            VelocityVector *= (MaxVelocity / VelocityVector.magnitude);

        transform.Translate(VelocityVector);
    }
}