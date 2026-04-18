using System.Data;
using UnityEngine;

public class King : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector2Int pos;
    void Start()
    {
        transform.position=GridManager.Instance.GridToWorld(pos);
        if(GridManager.Instance.IsBlocked(pos))
        {
            Debug.LogError("Invalid position for King");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
