using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnTypes;
    public List<GameObject> spawns;
    public bool active;
    public float health = 15;
    public float[] time;
    public int[] amount;
    public int maxSpawns;

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
        for(int x = 0; x < spawns.Count; x++)
        {
            if(spawns[x] == null){
                spawns.RemoveAt(x);
            }
        }

        for (int j = 0; j < amount[i]; j++)
        {
            if(spawns.Count < maxSpawns)
            spawns.Add(Instantiate(spawnTypes[i], this.transform.position, Quaternion.identity));
            
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
