using TMPro;
using UnityEngine;

public class Jamdicator : MonoBehaviour
{
    public TMP_Text text;

    public GunScript Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<GunScript>();   
    }

    void Update()
    {
        text.text = $"Jammo: {Player.AmmoCount}";
        text.color = Player.Ammo switch
        {
            AmmoType.STRAWBERRY => new Color(0.8f, 0.3f, 0.3f, 1),
            AmmoType.GRAPESHOT => new Color(0.6f, 0.3f, 0.5f, 1),
            AmmoType.MARMALADE => new Color(1f, 165f / 255f, 0f, 1),
            AmmoType.PEPPER => new Color(0, 30, 190, 1)
        };
    }
}
