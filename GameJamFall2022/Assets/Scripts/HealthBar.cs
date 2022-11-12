using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthBar : MonoBehaviour
{
    public TMP_Text text;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        text.text = "Health: " + player.health;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Health: " + player.health;
    }
}
