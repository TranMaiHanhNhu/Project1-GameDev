using UnityEngine;

public class FogManager : MonoBehaviour
{
    public static FogManager Instance;

    public GameObject fogPrefab;
    private FogTile[,] fogGrid;

    void Awake()
    {
        Instance = this;
        GenerateFog();
    }

    void Start()
    {
    }

    void GenerateFog()
    {
        int w = GridManager.Instance.width;
        int h = GridManager.Instance.height;

        fogGrid = new FogTile[w, h];

        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                Vector3 pos = GridManager.Instance.GridToWorld(new Vector2Int(x, y));
                GameObject obj = Instantiate(fogPrefab, pos, Quaternion.identity);
                fogGrid[x, y] = obj.GetComponent<FogTile>();
            }
        }
    }
    public void ResetFog()
    {
        int w = GridManager.Instance.width;
        int h = GridManager.Instance.height;

        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                if (fogGrid[x, y] != null)
                {
                    fogGrid[x, y].gameObject.SetActive(true);
                    fogGrid[x, y].revealed = false;
                }
            }
        }
    }

    public FogTile GetFog(Vector2Int pos)
    {
        return fogGrid[pos.x, pos.y];
    }
}