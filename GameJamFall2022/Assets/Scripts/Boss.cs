using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum BossPhase { FOOT, HAND, FINISHED};
public class Boss : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject bossLeg;
    public GameObject bossHand;
    public float legHealth = 30;
    public int legInterval;
    public int handInterval;
    public BossPhase phase = BossPhase.FOOT;
    void Awake()
    {
        bossLeg = GameObject.Instantiate(prefabs[0]);
        bossLeg.GetComponent<BossLeg>().interval = legInterval;
        bossLeg.GetComponent<BossLeg>().Begin();
        bossLeg.GetComponent<BossLeg>().boss = this;

        
    }

    public void CreateHand()
    {
        bossHand = GameObject.Instantiate(prefabs[1]);
        bossHand.GetComponent<BossLeg>().interval = handInterval;
        bossHand.GetComponent<BossLeg>().boss = this;
        bossHand.GetComponent<BossLeg>().Begin();
        legHealth = 30;
    }

    private void Update()
    {
        if(phase == BossPhase.FOOT) 
        { 
            if(legHealth <= 0) 
            {
                bossLeg.GetComponent<BossLeg>().Die();
                phase = BossPhase.HAND;
            }
        }
        if(phase == BossPhase.HAND) 
        {
            if(bossLeg == null) 
            {
                if (bossHand == null)
                {
                    CreateHand();
                }
                if (legHealth <= 0)
                {
                    bossHand.GetComponent<BossLeg>().Die();
                    Debug.Log("You win!");
                    phase = BossPhase.FINISHED;
                }
            }
        }
    }

}
