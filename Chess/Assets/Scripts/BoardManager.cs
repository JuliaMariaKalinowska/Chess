using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int x_size, z_size;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Piece piecePrefab;
    [SerializeField] private Transform cam;

    private Dictionary<Vector2, Tile> tiles;
    //private Dictionary<Vector2, Tile> pieces;

    void Start()
    {
        SetupBoard();
    }

    void SetupBoard()
    {
        cam.transform.position = new Vector3((float)x_size / 2 - 0.5f, 5, -2);
        cam.transform.rotation = new Quaternion(0.382683426f, 0, 0, 0.923879564f);

        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < x_size; x++)
        {
            for (int z = 0; z < z_size; z++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, 0, z), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {z}";

                var isOffset = (x % 2 == 0 && z % 2 != 0) || (x % 2 != 0 && z % 2 == 0);
                spawnedTile.Init(isOffset);


                tiles[new Vector2(x, z)] = spawnedTile;
            }
        }

        // Spawn whites
        for (int i = 0; i < x_size; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                var spawnedPiece = Instantiate(piecePrefab, new Vector3(i, 1, j), Quaternion.identity);
                spawnedPiece.name = $"White {i} {j}";

                spawnedPiece.Init(true);

                GetTileAtPosition(new Vector2(i, j)).occupant = spawnedPiece;
                //tiles[new Vector2(x, z)] = spawnedTile;
            }
        }

        // Spawn blacks
        for (int i = 0; i < x_size; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                var spawnedPiece = Instantiate(piecePrefab, new Vector3(i, 1, z_size - j - 1), Quaternion.identity);
                spawnedPiece.name = $"Black {i} {j}";

                spawnedPiece.Init(false);

                GetTileAtPosition(new Vector2(i, z_size - j - 1)).occupant = spawnedPiece;
                //tiles[new Vector2(x, z)] = spawnedTile;
            }
        }
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}
