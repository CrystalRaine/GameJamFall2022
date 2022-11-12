using UnityEngine;

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

    public enum AmmoType
    {
        STRAWBERRY,
        GRAPESHOT,
        MARMALADE,
        PEPPER
    }

    void Update()
    {
        Vector2 aimVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        var dot = Vector2.Dot(Vector2.right, aimVector);

        if (dot > 0)
            transform.localScale = new Vector3(1, 1);
        else if (dot < 0)
            transform.localScale = new Vector3(-1, 1);

        if (Arm != null)
            Arm.transform.right = aimVector * dot / Mathf.Abs(dot);

        if (Input.GetMouseButton(0) && currentCooldown <= 0)
        {
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
}
