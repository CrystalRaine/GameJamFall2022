using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericDeath : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("empty"))
        {
            Destroy(this.gameObject); 
        }
    }
}
