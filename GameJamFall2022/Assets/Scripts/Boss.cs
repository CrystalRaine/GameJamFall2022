using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject bossLeg;
    public GameObject bossHand;
    public float legHealth = 5;
    void Awake()
    {
        bossLeg = GameObject.Instantiate(prefabs[0]);
        bossLeg.GetComponent<BossLeg>().interval = 4;
        bossLeg.GetComponent<BossLeg>().Begin();
        bossLeg.GetComponent<BossLeg>().boss = this;

        
    }

    public void CreateHand()
    {
        bossHand = GameObject.Instantiate(prefabs[1]);
        bossHand.GetComponent<BossLeg>().interval = 2;
        bossHand.GetComponent<BossLeg>().boss = this;
        bossHand.GetComponent<BossLeg>().Begin();
        legHealth = 30;
    }

    private void Update()
    {
        if(legHealth <= 0 && bossHand == null) 
        {
            if(bossLeg != null && bossHand == null) 
            {
                bossLeg.GetComponent<BossLeg>().Die();
                
            }
            else 
            {
                CreateHand();
            }

        }
        else if(legHealth <= 0) 
        {
            if (bossHand != null)
            {
                bossHand.GetComponent<BossLeg>().Die();
                Debug.Log("You win!");
                Destroy(this.gameObject);
            }
        }
    }

}
