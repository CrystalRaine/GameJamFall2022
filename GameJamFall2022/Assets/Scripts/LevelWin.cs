using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWin : MonoBehaviour
{
    public Spawner[] spawnersRemaining;
    // Start is called before the first frame update
    
    public bool isFinished() 
    { 
        for(int i = 0; i < spawnersRemaining.Length; i++) 
        {
            if (spawnersRemaining[i].health > 0) 
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
            Debug.Log("You win!");
        }
    }
}
