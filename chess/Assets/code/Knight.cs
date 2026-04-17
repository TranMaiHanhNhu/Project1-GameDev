using UnityEngine;

public class Knight : PieceController
{
    Vector2Int[] moves = {
        new Vector2Int(1,2),
        new Vector2Int(2,1),
        new Vector2Int(-1,2),
        new Vector2Int(-2,1),
        new Vector2Int(1,-2),
        new Vector2Int(2,-1),
        new Vector2Int(-1,-2),
        new Vector2Int(-2,-1)
    };

    public override bool IsValidMove(Vector2Int from, Vector2Int to)
    {
        int dx = Mathf.Abs(from.x - to.x);
        int dy = Mathf.Abs(from.y - to.y);

        return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
    }

    public override bool IsPathClear(Vector2Int from, Vector2Int to)
    {
        if(!GridManager.Instance.IsInside(to)|| GridManager.Instance.IsBlocked(to))
        {
            return false; // nhảy qua được
        }

        return true;
    }
    public override void RevealAllDirections()
    {
        // reveal ô hiện tại
        var fog = FogManager.Instance.GetFog(gridPos);
        if (fog != null)
            fog.Reveal();

        foreach (var move in moves)
        {
            Vector2Int target = gridPos + move;

            if (!GridManager.Instance.IsInside(target))
                continue;

            fog = FogManager.Instance.GetFog(target);
            if (fog != null)
                fog.Reveal();
        }
    }
}