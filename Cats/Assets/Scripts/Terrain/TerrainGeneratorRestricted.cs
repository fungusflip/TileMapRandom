using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class RareTile1
{
    public Tile tile;
    [Range(0f, 1f)]
    public float probability;
}

public class TerrainGeneratorRestricted : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile[] frequentTiles;
    [SerializeField] private RareTile1[] rareTiles;
    [SerializeField] private Transform centerObject;

    [SerializeField] private int width = 100;
    [SerializeField] private int height = 100;

    private BoundsInt generatedAreaBounds;

    private Vector3 initialCenterPosition;

    private void Start()
    {
        initialCenterPosition = centerObject.position;
        GenerateTiles();
    }

    private void Update()
    {
        // Restrict centerObject movement within the generated area
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(centerObject.position.x, initialCenterPosition.x - width / 2f, initialCenterPosition.x + width / 2f),
            Mathf.Clamp(centerObject.position.y, initialCenterPosition.y - height / 2f, initialCenterPosition.y + height / 2f),
            centerObject.position.z
        );
        centerObject.position = clampedPosition;
    }

    void GenerateTiles()
    {
        Vector3Int origin = tilemap.WorldToCell(centerObject.position);

        int startX = origin.x - width / 2;
        int startY = origin.y - height / 2;

        for (int x = startX; x < startX + width; x++)
        {
            for (int y = startY; y < startY + height; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                Tile tile = GetTileForPosition(tilePos);
                tilemap.SetTile(tilePos, tile);
            }
        }

        generatedAreaBounds = new BoundsInt(startX, startY, 0, width, height, 1);
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
}
