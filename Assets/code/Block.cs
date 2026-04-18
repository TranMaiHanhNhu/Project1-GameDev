using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector2Int gridPos;
    void Start()
    {
        transform.position = GridManager.Instance.GridToWorld(gridPos);
        GridManager.Instance.map[gridPos.x, gridPos.y] = 1; // đánh dấu block trên map
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if(!GridManager.Instance.IsInside(gridPos))
    //     {
    //         Debug.LogError("Block position is out of bounds: " + gridPos);
    //         Destroy(this.gameObject);
    //     }
    // }
}
