using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorGeneration : MonoBehaviour
{

    public List<TileBase> tiles;

    public int sizeX;
    public int sizeY;

    // Start is called before the first frame update
    void Start()
    {
        Tilemap floor = gameObject.transform.GetComponentInChildren<Tilemap>();
        floor.ClearAllTiles();

        for (int i = sizeX; i < sizeX; i++)
        {
            for (int j = -sizeY; j < sizeY; j++)
            {
                floor.SetTile(new Vector3Int(i, j, 0), tiles[Random.Range(0, tiles.Count-1)]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
