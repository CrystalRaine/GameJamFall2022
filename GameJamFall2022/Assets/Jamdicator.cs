using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Jamdicator : MonoBehaviour
{
    public TMP_Text text;

    public GunScript Player;

    void Update()
    {
        text.text = $"Jammo: {Player.AmmoCount}";

    }
}
