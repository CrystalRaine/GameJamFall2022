using UnityEngine;
using UnityEditor.Animations;

public class PlayerController : MonoBehaviour
{
    public float MaxVelocity = 3;
    public float Acceleration = .5f;
    public float Damping = 1;
    private Vector2 VelocityVector;
    private SpriteRenderer sprite;
    public int health = 10;
    public Animator bimbertanimator;
    public Animator jamanimator;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var mag = VelocityVector.magnitude * (1 - Damping * Time.deltaTime);

        if (mag > 0)
            VelocityVector = VelocityVector.normalized * mag;
        else
            VelocityVector = Vector2.zero;

        if(VelocityVector.magnitude < 1f){
            bimbertanimator.SetBool("moving", false);
            jamanimator.SetBool("moving", false);
        }
        else{
            bimbertanimator.SetBool("moving", true);
            jamanimator.SetBool("moving", true);
        }
        var accelerationVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized
            * Time.deltaTime * Acceleration;

        VelocityVector += accelerationVector;

        if(VelocityVector.magnitude >= MaxVelocity) // if above max velocity
        {
            VelocityVector.Normalize();             // set velocity to max velocity
            VelocityVector *= MaxVelocity;
        }

        transform.Translate(VelocityVector * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Boss") 
        {
            this.health -= 5;
        }
    }
}