using UnityEngine;

public abstract class PieceController : MonoBehaviour
{
    public Vector2Int gridPos;
    public bool isUnlocked = false;

    protected virtual void Start()
    {
        transform.position = GridManager.Instance.GridToWorld(gridPos);
        if(isUnlocked)
        {
            RevealTileAndUnlock(gridPos);
        }
    }
    public abstract bool IsValidMove(Vector2Int from, Vector2Int to);

    public abstract bool IsPathClear(Vector2Int from, Vector2Int to);


    // mỗi quân tự định nghĩa cách reveal
    public abstract void RevealAllDirections();

    protected void RevealInDirection(Vector2Int dir)
    {
        Vector2Int current = gridPos;

        if (dir == Vector2Int.zero)
        {
            RevealTileAndUnlock(current);
            return;
        }

        while (true)
        {
            current += dir;

            if (!GridManager.Instance.IsInside(current))
                break;

            RevealTileAndUnlock(current);

            if (GridManager.Instance.IsBlocked(current))
                break;
        }
    }
    void RevealTileAndUnlock(Vector2Int pos)
    {
        var fog = FogManager.Instance.GetFog(pos);
        if (fog != null)
            fog.Reveal();

        // 🔥 check có quân không → unlock
        Collider2D hit = Physics2D.OverlapPoint(
            GridManager.Instance.GridToWorld(pos)
        );

        if (hit != null)
        {
            PieceController piece = hit.GetComponent<PieceController>();

            if (piece != null)
            {
                piece.isUnlocked = true;
                Debug.Log("Unlock: " + piece.name);
            }
        }
    }
}