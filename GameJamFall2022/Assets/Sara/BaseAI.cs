<<<<<<< Updated upstream
using System;
=======
>>>>>>> Stashed changes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour
{
<<<<<<< Updated upstream
    public GameObject enemy;
    Vector3 currentGoal;

    public float maxX = 10;
    public float maxY = 4.5f;
    public float minX = -10;
    public float minY = -4.5f;
    public float movementRange = 3;
    public float step = .005f;

=======
    public GameObject circle;
    Vector3 currentGoal;
>>>>>>> Stashed changes
    private void Start()
    {
        currentGoal = GetRandomPositionNearSelf();
    }
    public void MoveToGoal(Vector2 goal)
    {
<<<<<<< Updated upstream
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, goal, step);
=======
        circle.transform.position = Vector2.MoveTowards(circle.transform.position, goal, .005f);
>>>>>>> Stashed changes
    }

    public Vector3 GetRandomPositionNearSelf()
    {
<<<<<<< Updated upstream
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
        if (Vector3.Distance(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), enemy.transform.position) < radius) { Debug.Log("True");  return true; } else { return false; }
    }
    // Update is called once per frame
    void Update()
    {
        if (NearPlayer(8))
        {
            currentGoal = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
        
        if (Vector3.Distance(enemy.transform.position, currentGoal) >= .001)
        {
            MoveToGoal(currentGoal);
        }
        else if(Vector3.Distance(enemy.transform.position, currentGoal) <= .001 && !NearPlayer(8))
        {

            currentGoal = GetRandomPositionNearSelf();
        }

=======
        Vector3 random = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        random = new Vector3(circle.transform.position.x + random.x, circle.transform.position.y + random.y, 0);
        if(random.x <= -10) { random.x = -10; }
        if(random.x >= 10) { random.x = 10; }
        if(random.y <= -5) { random.y = -4.5f; }
        if(random.y >= 5) { random.y = 4.5f; }
        return random;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (circle.transform.position != currentGoal)
        {
            MoveToGoal(currentGoal);
        }
        else
        {
            currentGoal = GetRandomPositionNearSelf();

        }
        
>>>>>>> Stashed changes
    }
}
