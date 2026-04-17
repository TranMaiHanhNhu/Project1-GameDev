using UnityEngine;

public class Rook : PieceController
{
    Vector2Int[] directions = {
        new Vector2Int(0,0),
        new Vector2Int(1,0),
        new Vector2Int(-1,0),
        new Vector2Int(0,1),
        new Vector2Int(0,-1)
    };
    public override bool IsValidMove(Vector2Int from, Vector2Int to)
    {
        return from.x == to.x || from.y == to.y;
    }

    public override bool IsPathClear(Vector2Int from, Vector2Int to)
    {
        Vector2Int dir = new Vector2Int(
            Mathf.Clamp(to.x - from.x, -1, 1),
            Mathf.Clamp(to.y - from.y, -1, 1)
        );

        Vector2Int current = from;

        while (current != to)
        {
            current += dir;

            if (GridManager.Instance.IsBlocked(current))
                return false;
        }

        return true;
    }

    public override void RevealAllDirections()
    {
        foreach (var dir in directions)
        {
            RevealInDirection(dir);
        }
    }
}