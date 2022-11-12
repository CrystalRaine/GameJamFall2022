using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarmalaserSection : MonoBehaviour
{
    public List<Sprite> sprites;
    public List<Sprite> splash;
    public int count = 5;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        if (count > 0)
        {
            Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position);
            GameObject obj = GameObject.Instantiate(gameObject);
            dir.Normalize();
            obj.GetComponent<MarmalaserSection>().count = count - 1;
            obj.transform.position = gameObject.transform.position + (new Vector3(dir.x, dir.y, 0) * 0.9f);
            obj.transform.Rotate(new Vector3(0, 0, Vector3.Angle(new Vector3(0, 1, 0), dir)));

        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count-1)];
    }
}
