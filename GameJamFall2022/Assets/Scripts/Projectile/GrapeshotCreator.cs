using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeshotCreator : Projectile
{
    public GameObject particle;
    public int count;
    public float speed;
    public float spreadDegrees;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject inst = GameObject.Instantiate(particle);
            
            Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position).normalized;

            dir = Quaternion.AngleAxis(Random.Range(-spreadDegrees/2, spreadDegrees / 2), Vector3.forward) * dir;

            inst.GetComponent<Rigidbody2D>().velocity = (dir / dir.magnitude) * speed;
            inst.transform.Rotate(new Vector3(0, 0, Vector3.Angle(new Vector3(0, 1, 0), dir)));
            
            inst.transform.position = gameObject.transform.position;
        }
    }
}
