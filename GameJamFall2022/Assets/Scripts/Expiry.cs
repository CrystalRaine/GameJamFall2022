using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expiry : MonoBehaviour
{
    public float lifetimeSeconds;
    void Update()
    {
        lifetimeSeconds-= Time.deltaTime;
        if(lifetimeSeconds <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
