using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWin : MonoBehaviour
{
    public Spawner[] spawnersRemaining;
    // Start is called before the first frame update

    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public bool isFinished() 
    { 
        for(int i = 0; i < spawnersRemaining.Length; i++) 
        {
            
            if (spawnersRemaining[i] != null) 
            {
                return false;
            }
        }
        return true;
    }

    private void Update()
    {
        if(isFinished())
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
