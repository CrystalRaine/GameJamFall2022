using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MarmalaserSection : MonoBehaviour
{
    public List<Sprite> sprites;
    public List<Sprite> splash;
    public int count;
    public Vector2 dir;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = count % 3;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        if (count > 0)
        {
            if(this.dir.Equals(new Vector2()))
            {
                dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position);
                gameObject.transform.Rotate(new Vector3(0, 0, Vector3.SignedAngle(new Vector3(1, 0, 0), dir, Vector3.forward)));
                dir.Normalize();
            }
            GameObject obj = GameObject.Instantiate(gameObject);
            obj.GetComponent<MarmalaserSection>().dir = this.dir;
            obj.GetComponent<MarmalaserSection>().count = count - 1;
            obj.transform.position = gameObject.transform.position + (new Vector3(dir.x, dir.y, 0) * 0.9f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
        index++;
        index %= 3;
    }
}
