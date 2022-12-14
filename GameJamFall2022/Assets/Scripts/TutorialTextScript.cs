using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialTextScript : MonoBehaviour
{

    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && text != null) {
            text.gameObject.SetActive(true);
            Expiry ex = text.gameObject.AddComponent<Expiry>();
            ex.lifetimeSeconds = 5;
        }
    }
}
