using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float damage;
    public bool destroyOnHit;
    public BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        bc = this.gameObject.GetComponent<BoxCollider2D>();
    }

    
}
