using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossLeg : MonoBehaviour
{
    public GameObject leg;
    public Vector3 originalSpot;
    public Vector2 stompPlace;
    public float movementRange;
    public GameObject player;
    public int interval;
    public GameObject shadowPrefab;
    public GameObject shadow;
    // Start is called before the first frame update
    void Awake()
    {
        leg = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        NewPlace();
        InvokeRepeating("Attack", interval, interval);
    }

    public void NewPlace() 
    {
        
        
        Vector3 newOrigin = new Vector3(player.transform.position.x, player.transform.position.y + 20, 0);

        Vector2 newStompPlace = player.transform.position;
        originalSpot = newOrigin;
        leg.transform.position = originalSpot;
        stompPlace = newStompPlace;
        
        
    }

    public void Attack() 
    {
        StartCoroutine("Stomp");
    }

    IEnumerator Stomp() 
    {

        while ((Vector2)leg.transform.position != stompPlace) 
        {
            leg.transform.position = Vector2.MoveTowards(leg.transform.position, stompPlace, .1f);
            //shadow.transform.localScale = new Vector3(shadow.transform.localScale.x + .01f, shadow.transform.localScale.y + .01f, 0);
            yield return null;
        }
        if((Vector2)leg.transform.position == stompPlace) 
        {
            Debug.Log("Finished");
            StartCoroutine("Wait");
        }
        
    }

    IEnumerator Wait() 
    {
        yield return new WaitForSecondsRealtime(1);
        StartCoroutine("Withdraw");
    }

    IEnumerator Withdraw()
    {
        while (leg.transform.position != originalSpot)
        {
            leg.transform.position = Vector2.MoveTowards(leg.transform.position, originalSpot, .1f);
            shadow.transform.localScale = new Vector3(shadow.transform.localScale.x - .1f, shadow.transform.localScale.y - .1f, 0);

            yield return null;
        }
        if (leg.transform.position == originalSpot)
        {
            
            Debug.Log("Finished");
            NewPlace();
        }
       // Destroy(shadow);
        ///shadow = null;
    }


}
