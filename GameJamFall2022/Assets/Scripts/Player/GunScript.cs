using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{
    STRAWBERRY,
    GRAPESHOT,
    MARMALADE,
    PEPPER
}

public class GunScript : MonoBehaviour
{
    public int AmmoCount;
    public GameObject Arm;

    public GameObject Strawberry;
    public GameObject Grapeshot;
    public GameObject OrangeMarmalade;
    public GameObject Pepper;

    public AmmoType Ammo;

    public Dictionary<AmmoType, float> Cooldowns;

    private float currentCooldown;

    private void Start()
    {
        Cooldowns = new Dictionary<AmmoType, float>() 
        {
            {AmmoType.STRAWBERRY, 2},
            {AmmoType.GRAPESHOT, 4},
            {AmmoType.MARMALADE, 0},
            {AmmoType.PEPPER, .5f},
        };
    }

    void Update()
    {
        var color = Ammo switch
        {
            AmmoType.STRAWBERRY => new Color(0.8f, 0.3f, 0.3f, 1),
            AmmoType.GRAPESHOT => new Color(0.6f, 0.3f, 0.5f, 1),
            AmmoType.MARMALADE => new Color(1f, 165f / 255f, 0f, 1),
            AmmoType.PEPPER => new Color(0, 30, 190, 1)
        };

        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
        gameObject.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = color;

        Vector2 aimVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        var dot = Vector2.Dot(Vector2.right, aimVector);

        if (dot > 0)
            transform.localScale = new Vector3(2, 2);
        else if (dot < 0)
            transform.localScale = new Vector3(-2, 2);

        if (Arm != null)
            Arm.transform.right = aimVector * dot / Mathf.Abs(dot);

        if (Input.GetMouseButton(0) && currentCooldown <= 0 && AmmoCount > 0)
        {
            AmmoCount--;
            currentCooldown = Cooldowns[Ammo];
            Instantiate(
                Ammo switch
                {
                    AmmoType.STRAWBERRY => Strawberry,
                    AmmoType.GRAPESHOT => Grapeshot,
                    AmmoType.MARMALADE => OrangeMarmalade,
                    AmmoType.PEPPER => Pepper
                }, transform.position, Quaternion.identity);
        }
        currentCooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jam")
        {
            var item = collision.gameObject.GetComponent<JamItem>();

            if (Ammo != item.Ammo)
                AmmoCount = 0;

            Ammo = item.Ammo;
            AmmoCount += item.AmmoCount;

            Destroy(collision.gameObject);
        }
    }
}