using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Boss boss;
    public bool burning;
    // Start is called before the first frame update
    public void Begin()
    {
        leg = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        NewPlace();
        InvokeRepeating("Attack", interval, interval);
    }

    private void Update()
    {
        if (burning == true)
        {
            boss.legHealth--;
            if (boss.legHealth <= 0) { Destroy(this.gameObject); }
            burning = false;
        }
    }

    public void Die()
    {
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = false;
        }
        if(shadow != null) 
        {
            GameObject.Destroy(shadow);
            shadow = null;
        }
        StartCoroutine("FallOver");
    }

    IEnumerator Disappear() 
    {
        yield return new WaitForSecondsRealtime(2);
        boss.bossLeg = null;
        boss.bossHand = null;
        GameObject.Destroy(this.gameObject);
        StartCoroutine("FinalWait");
    }

    public void NewPlace() 
    {
        if(shadow != null) 
        {
            Destroy(shadow);
            shadow = null;
        }
        Vector3 newOrigin = new Vector3(player.transform.position.x, player.transform.position.y + 20, 0);

        Vector2 newStompPlace = player.transform.position;
        originalSpot = newOrigin;
        leg.transform.position = originalSpot;
        stompPlace = newStompPlace;
        shadow = GameObject.Instantiate(shadowPrefab, stompPlace, Quaternion.identity);

    }

    public void Attack() 
    {
        if(boss.legHealth > 0) 
        {
            StartCoroutine("Stomp");
        }
        
    }

    IEnumerator Stomp() 
    {
        
        while ((Vector2)leg.transform.position != stompPlace) 
        {
            leg.transform.position = Vector2.MoveTowards(leg.transform.position, stompPlace, .1f);
            shadow.transform.localScale = new Vector3(shadow.transform.localScale.x + .02f, shadow.transform.localScale.y + .02f, 0);
            yield return null;
        }
        if((Vector2)leg.transform.position == stompPlace) 
        {
            StartCoroutine("Wait");
        }
        
    }

    IEnumerator Wait() 
    {
        yield return new WaitForSecondsRealtime(3);
        
        StartCoroutine("Withdraw");
    }

    IEnumerator FinalWait()
    {
        yield return new WaitForSecondsRealtime(3);

        StartCoroutine("FallOver");
    }

    IEnumerator FallOver() 
    {
        
        int targetZ;
        if(this.gameObject.GetComponent<SpriteRenderer>().flipX) 
        {
            targetZ = -90;
        }
        else
        {
            targetZ = 90;
        }
        Quaternion target = Quaternion.Euler(new Vector3(0, 0, targetZ));
        while (leg.transform.rotation != target)
        {
            leg.transform.position = stompPlace;
            leg.transform.rotation = Quaternion.Lerp(leg.transform.rotation, Quaternion.Euler(new Vector3(0, 0, targetZ)), .01f);
            yield return null;
        }
        if(leg.transform.rotation == target) 
        {
            StartCoroutine("Disappear");
        }
    }

    IEnumerator Withdraw()
    {
        while (leg.transform.position != originalSpot && boss.legHealth > 0)
        {
            leg.transform.position = Vector2.MoveTowards(leg.transform.position, originalSpot, .1f);
            if(shadow != null) 
            {
                if (shadow.transform.localScale.x > 0)
                {
                    shadow.transform.localScale = new Vector3(shadow.transform.localScale.x - .1f, shadow.transform.localScale.y - .1f, 0);
                }
                else
                {
                    Destroy(shadow);
                    shadow = null;
                }
            }
            

            yield return null;
        }
        if (leg.transform.position == originalSpot)
        {
            NewPlace();

        }
       
    }

    IEnumerator FinalWithdraw()
    {
        while (leg.transform.position != originalSpot)
        {
            leg.transform.position = Vector2.MoveTowards(leg.transform.position, originalSpot, .1f);
            //shadow.transform.localScale = new Vector3(shadow.transform.localScale.x - .1f, shadow.transform.localScale.y - .1f, 0);

            yield return null;
        }
        if (leg.transform.position == originalSpot)
        {
            
            

        }
        Destroy(shadow);
        shadow = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Projectile")
        {
            if (collision.gameObject.GetComponent<Projectile>().destroyOnHit)
            {
                Destroy(collision.gameObject);
            }
            boss.legHealth -= collision.gameObject.GetComponent<Projectile>().damage;
            if (collision.gameObject.name == "Peppershot")
            {
                burning = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            MarmalaserSection p;

            if (collision.gameObject.TryGetComponent<MarmalaserSection>(out p))
            {
                boss.legHealth -= collision.gameObject.GetComponent<Projectile>().damage * Time.deltaTime;
            }
        }
    }

}
