using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnTypes;
    public bool active;
    public float health = 15;
    public float[] time;
    public int[] amount;

    private List<float> times = new();

    // Start is called before the first frame update
    void Start()
    {
        if(active) 
        {
            for (int i = 0; i < spawnTypes.Length; i++)
                times.Add(time[i]);
                //InvokeRepeating("SpawnBread", 0, 5);
                //InvokeRepeating("SpawnCrumb", 5, 15);
        }
    }

    private void Update()
    {
        for (int i = 0; i < times.Count; i++)
        {
            var v = times[i] = times[i] - Time.deltaTime;

            if (v <= 0)
            {
                times[i] = time[i];
                Spawn(i);
            }
        }
    }

    public void Spawn(int i)
    {
        Debug.Log(i);
        for (int j = 0; j < amount[i]; j++)
            Instantiate(spawnTypes[i], this.transform.position, Quaternion.identity);
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
        if (collision.gameObject.tag == "Projectile")
        {
            if (collision.gameObject.GetComponent<Projectile>().destroyOnHit)
            {
                Destroy(collision.gameObject);
            }
            Pepper p;
            if (collision.gameObject.TryGetComponent<Pepper>(out p))
            {
                gameObject.AddComponent<DOT>();
            }
            health -= collision.gameObject.GetComponent<Projectile>().damage;
            if (health <= 0) { Destroy(this.gameObject); }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            MarmalaserSection p;

            if (collision.gameObject.TryGetComponent<MarmalaserSection>(out p))
            {
                health -= collision.gameObject.GetComponent<Projectile>().damage;
            }
        }
    }
}
