using UnityEngine;

public class mouseFollow : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }
}

