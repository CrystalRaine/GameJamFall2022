using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOT : MonoBehaviour
{

    private float timer = 1;
    private float maxTime = 1;
    void Update()
    {
        if(timer < 0)
        {
            timer = maxTime;
            BaseAI bai = null;
            Spawner sp = null;
            if(gameObject.TryGetComponent<BaseAI>(out bai))
            {
                bai.health--;
            }
            if(gameObject.TryGetComponent<Spawner>(out sp))
            {
                sp.health--;
            }
        }
        timer -= Time.deltaTime;
    }

}
