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
            sprite.flipX = false;
        else if (Input.GetAxis("Horizontal") < 0)
            sprite.flipX = true;

        var mag = (VelocityVector.magnitude - Damping * Time.deltaTime);

        if (mag > 0)
            VelocityVector = VelocityVector.normalized * mag;
        else
            VelocityVector = Vector2.zero;

        var accelerationVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized
            * Time.deltaTime * Acceleration;

        VelocityVector += accelerationVector;

        transform.Translate(VelocityVector * Time.deltaTime);
    }
}