using System.Collections;
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

    public float cooldown;
    private float currentCooldown;

    void Update()
    {

        switch(Ammo)
        {
            case AmmoType.STRAWBERRY:
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.8f,0.3f,0.3f, 1);
                break;
            case AmmoType.GRAPESHOT:
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.3f, 0.5f, 1);
                break;
            case AmmoType.MARMALADE:
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 165f / 255f, 0f,1 );
                break;
            case AmmoType.PEPPER:
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 43f / 255f, 0f, 1);
                break;
        };




        Vector2 aimVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        var dot = Vector2.Dot(Vector2.right, aimVector);

        if (dot > 0)
            transform.localScale = new Vector3(1, 1);
        else if (dot < 0)
            transform.localScale = new Vector3(-1, 1);

        if (Arm != null)
            Arm.transform.right = aimVector * dot / Mathf.Abs(dot);

        if (Input.GetMouseButton(0) && currentCooldown <= 0 && AmmoCount > 0)
        {
            AmmoCount--;
            currentCooldown = cooldown;
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