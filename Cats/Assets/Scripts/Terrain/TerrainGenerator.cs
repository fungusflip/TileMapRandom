using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class RareTile
{
    public Tile tile;
    [Range(0f, 1f)]
    public float probability;
}

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile[] frequentTiles;
    [SerializeField] private RareTile[] rareTiles;
    [SerializeField] private Transform centerObject;

    [SerializeField] private int radius = 100;
    [SerializeField] private int fillRadius = 5;

    private Vector3Int lastCenterCell;

    void Start()
    {
        GenerateTiles();
    }

    void Update()
    {
        Vector3Int currentCenterCell = tilemap.WorldToCell(centerObject.position);

        if (currentCenterCell != lastCenterCell)
        {
            FillEmptyTiles(currentCenterCell);
            lastCenterCell = currentCenterCell;
        }
    }

    void GenerateTiles()
    {
        Vector3Int origin = tilemap.WorldToCell(centerObject.position);

        for (int x = -radius; x <= radius; x++)
        {
            for (int y = -radius; y <= radius; y++)
            {
                Vector3Int tilePos = origin + new Vector3Int(x, y, 0);
                Tile tile = GetTileForPosition(tilePos);
                tilemap.SetTile(tilePos, tile);
            }
        }
    }

    Tile GetTileForPosition(Vector3Int position)
    {
        if (Random.value < GetTotalProbability())
        {
            float randomValue = Random.value;
            float cumulativeProbability = 0f;

            foreach (var rareTile in rareTiles)
            {
                cumulativeProbability += rareTile.probability;

                if (randomValue <= cumulativeProbability)
                {
                    return rareTile.tile;
                }
            }
        }

        int frequentIndex = Random.Range(0, frequentTiles.Length);
        return frequentTiles[frequentIndex];
    }

    float GetTotalProbability()
    {
        float totalProbability = 0f;
        foreach (var rareTile in rareTiles)
        {
            totalProbability += rareTile.probability;
        }
        return totalProbability;
    }

    void FillEmptyTiles(Vector3Int origin)
    {
        Vector3Int tilePos = Vector3Int.zero;
        for (int x = -fillRadius; x <= fillRadius; x++)
        {
            for (int y = -fillRadius; y <= fillRadius; y++)
            {
                tilePos.x = origin.x + x;
                tilePos.y = origin.y + y;
                if (tilemap.GetTile(tilePos) == null)
                {
                    Tile tile = GetTileForPosition(tilePos);
                    tilemap.SetTile(tilePos, tile);
                }
            }
        }
    }
}
