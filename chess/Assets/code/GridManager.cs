using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    public int width = 8;
    public int height = 8;
    public float cellSize = 1f;
    public GameObject whiteTile;
    public GameObject blackTile;

    public int[,] map; // 0 = trống, 1 = block

    void Awake()
    {
        Instance = this;
        map = new int[width, height];
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Chọn màu
                GameObject tilePrefab;
                if ((x + y) % 2 == 0)
                    tilePrefab = whiteTile;
                else
                    tilePrefab = blackTile;

                // Tạo ô
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);

                // (optional) cho gọn hierarchy
                tile.transform.parent = this.transform;
            }
        }
    }

    public Vector3 GridToWorld(Vector2Int pos)
    {
        return new Vector3(pos.x * cellSize, pos.y * cellSize, 0);
    }

    public Vector2Int WorldToGrid(Vector3 worldPos)
    {
        int x = Mathf.RoundToInt(worldPos.x / cellSize);
        int y = Mathf.RoundToInt(worldPos.y / cellSize);
        return new Vector2Int(x, y);
    }

    public bool IsInside(Vector2Int pos)
    {
        return pos.x >= 0 && pos.x < width && pos.y >= 0 && pos.y < height;
    }

    public bool IsBlocked(Vector2Int pos)
    {
        return map[pos.x, pos.y] == 1;
    }
}