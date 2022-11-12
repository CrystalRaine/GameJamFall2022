using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public enum LegState
{
    STOMP,
    WITHDRAW
}

public class BossLeg : MonoBehaviour
{
    public GameObject leg;
    public Vector3 originalSpot;
    public Vector2 stompPlace;
    public LegState currentState;
    public float movementRange;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        leg = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        NewPlace();
        InvokeRepeating("Attack", 0, 5);
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
        while((Vector2)leg.transform.position != stompPlace) 
        {
            leg.transform.position = Vector2.MoveTowards(leg.transform.position, stompPlace, .1f);
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
            yield return null;
        }
        if (leg.transform.position == originalSpot)
        {
            Debug.Log("Finished");
            NewPlace();
        }

    }


}
