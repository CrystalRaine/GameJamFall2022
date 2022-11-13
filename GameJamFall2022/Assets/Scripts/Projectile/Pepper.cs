using UnityEngine;

public class Pepper : Projectile
{
    public float Velocity;

    void Start()
    {
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position);

        GetComponent<Rigidbody2D>().velocity = dir / dir.magnitude * Velocity;

        transform.Rotate(new Vector3(0, 0, Vector3.SignedAngle(new Vector2(1, 0), dir, Vector3.forward)));

        transform.position = gameObject.transform.position;
    }
}
