using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    public GameObject tilePrefab;
    public Vector2 mapSize;
    [Range(0f, 1f)]
    public float outlinePercent;
    [SerializeField] private Transform mapHolder;

    private List<Tile> _tiles = new List<Tile>();

    private void Start() {
        GenerateMap();
    }

    public void GenerateMap() {
        for(int x = 0; x <= mapSize.x; x++) {
            for(int y = 0; y <= mapSize.y; y++) {
                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)).transform;
                newTile.localScale = Vector3.one * ( 1 - outlinePercent );
                newTile.parent = mapHolder;
            }
        }
    }

    public void SetVisible() {
        mapHolder.gameObject.SetActive(!mapHolder.gameObject.activeSelf);
    }
}
