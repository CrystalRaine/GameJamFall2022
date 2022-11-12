using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public GameObject circle;

    public void MoveToGoal(Vector2 goal)
    {
        Vector2.MoveTowards(circle.transform.position, goal, .1f);
    }

    public Vector2 GetRandomPositionNearSelf()
    {
        Vector2 random = new Vector2(Random.Range(0, .01f), Random.Range(0, .1f));
        random = new Vector2(circle.transform.position.x + random.x, circle.transform.position.y + random.y);
        return random;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToGoal(GetRandomPositionNearSelf());
    }
}
