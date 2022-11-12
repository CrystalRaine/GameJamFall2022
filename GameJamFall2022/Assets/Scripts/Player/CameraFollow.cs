using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject follows;
    public int inverseFollowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //follows = FindObjectOfType<GameObject>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = gameObject.transform.position - follows.transform.position;
        delta.z = 0;
        gameObject.transform.position -= delta / inverseFollowSpeed;

    }
}
