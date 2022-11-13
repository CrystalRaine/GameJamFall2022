using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{

    GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.FindGameObjectWithTag("CreditsScreen");
        screen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (screen.activeInHierarchy)
        {
            screen.SetActive(false);
        }
        else
        {
            screen.SetActive(true);
        }
    }
}
