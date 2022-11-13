using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthBar : MonoBehaviour
{
    public TMP_Text text;
    public PlayerController player;
    public Canvas loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        loseScreen.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        text.text = "Health: " + player.health;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Health: " + player.health;
        if(player.health < 0)
        {
            loseScreen.gameObject.SetActive(true);
        }
    }
}
