using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour
{
    public GameObject enemy;
    Vector3 currentGoal;

    public float maxX = 10;
    public float maxY = 4.5f;
    public float minX = -10;
    public float minY = -4.5f;
    public float movementRange = 3;
    public float step = .005f;
    public float health = 2;
    public GameObject player;
    public int attackCooldown = 300;
    private void Start()
    {
        currentGoal = GetRandomPositionNearSelf();
        player = GameObject.FindWithTag("Player");
    }
    public void MoveToGoal(Vector2 goal)
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, goal, step);

    }

    public Vector3 GetRandomPositionNearSelf()
    {
        Vector3 random = new Vector3(UnityEngine.Random.Range(-movementRange, movementRange), UnityEngine.Random.Range(-movementRange, movementRange));
        random = new Vector3(enemy.transform.position.x + random.x, enemy.transform.position.y + random.y, 0);
        if(random.x <= minX) { random.x = minX; }
        if(random.x >= maxX) { random.x = maxX; }
        if(random.y <= minY) { random.y = minY; }
        if(random.y >= maxY) { random.y = maxY; }
        return random;
    }

    public bool NearPlayer(float radius)
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) < radius) {  return true; } else { return false; }
    }
    public void AttackPlayer() 
    {
        if(attackCooldown <= 0) 
        {
            player.GetComponent<PlayerController>().health--;
            attackCooldown = 300;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(attackCooldown > 0) { attackCooldown--; }
        if(NearPlayer(1.5f)) { AttackPlayer(); }
        if (NearPlayer(8))
        {
            currentGoal = player.transform.position;
        }
        
        if (Vector3.Distance(enemy.transform.position, currentGoal) >= .001)
        {
            MoveToGoal(currentGoal);
        }
        else if(Vector3.Distance(enemy.transform.position, currentGoal) <= .001 && !NearPlayer(8))
        {

            currentGoal = GetRandomPositionNearSelf();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            if (collision.gameObject.GetComponent<Projectile>().destroyOnHit) 
            {
                Destroy(collision.gameObject);
            }
            health-= collision.gameObject.GetComponent<Projectile>().damage;
            if (health <= 0) { Destroy(this.gameObject); }
        }
    }

}
