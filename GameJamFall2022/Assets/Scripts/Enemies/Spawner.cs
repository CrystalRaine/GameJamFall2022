using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnTypes;
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
}
