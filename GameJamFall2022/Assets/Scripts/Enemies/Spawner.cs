using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnTypes;
    public float health = 15;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBread", 0, 5);
        InvokeRepeating("SpawnCrumb", 5, 15);
    }

    public void SpawnBread()
    {
        int num = 1;
        for(int i = 0; i < num; i++) 
        {
            GameObject go = GameObject.Instantiate(spawnTypes[0], this.transform.position, Quaternion.identity);
        }
    }
    public void SpawnCrumb()
    {
        int num = 5;
        for (int i = 0; i < num; i++)
        {
            GameObject go = GameObject.Instantiate(spawnTypes[1], this.transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            if (collision.gameObject.GetComponent<Projectile>().destroyOnHit)
            {
                Destroy(collision.gameObject);
            }
            health -= collision.gameObject.GetComponent<Projectile>().damage;
            if (health <= 0) { Destroy(this.gameObject); }
        }
    }
}
