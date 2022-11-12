using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnType;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, 5);
    }

    public void Spawn() 
    {
        GameObject go = GameObject.Instantiate(spawnType);
    }
}
