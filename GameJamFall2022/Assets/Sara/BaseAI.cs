using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour
{
    public GameObject circle;
    Vector3 currentGoal;
    private void Start()
    {
        currentGoal = GetRandomPositionNearSelf();
    }
    public void MoveToGoal(Vector2 goal)
    {
        circle.transform.position = Vector2.MoveTowards(circle.transform.position, goal, .005f);
    }

    public Vector3 GetRandomPositionNearSelf()
    {
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
        
    }
}
