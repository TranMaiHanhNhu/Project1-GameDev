using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    PieceController selectedPiece;
    public King king;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mouseScreen = Mouse.current.position.ReadValue();
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
            mouseWorld.z = 0;
            Vector2Int target = GridManager.Instance.WorldToGrid(mouseWorld);
            
            // ❌ ngoài map
            if (!GridManager.Instance.IsInside(target)) return;
            var fog = FogManager.Instance.GetFog(target);
            if (fog != null && !fog.revealed) return;
            // 🔥 1. Check click vào quân
            Collider2D hit = Physics2D.OverlapPoint(mouseWorld);

            if (hit != null)
            {
                
                PieceController piece = hit.GetComponent<PieceController>();

                if (piece != null)
                {
                    if (!piece.isUnlocked)
                    {
                        Debug.Log("Quân này chưa mở!");
                        return;
                    }

                    selectedPiece = piece;
                    
                    FogManager.Instance.ResetFog();
                    selectedPiece.RevealAllDirections();
                    Debug.Log("Selected piece");
                    return;
                }
            }

            // 🔥 2. Nếu chưa chọn quân → không làm gì
            if (selectedPiece == null) return;

            
            Vector2Int from = selectedPiece.gridPos;


            // ❌ ô chưa được reveal (fog)
           

            if(!selectedPiece.IsValidMove(from, target)) return;
            if(!selectedPiece.IsPathClear(from, target)) return;

            // ✅ MOVE
            selectedPiece.gridPos = target;
            selectedPiece.transform.position =
                GridManager.Instance.GridToWorld(target);

            GameManager.Instance.moveCount+=1;
            
            if (selectedPiece.gridPos==king.pos)
            {
                SceneManager.LoadScene("WinScene");
            }

            // 🔥 RESET + REVEAL
            FogManager.Instance.ResetFog();
            selectedPiece.RevealAllDirections();
        }
    }

    // 🎯 LUẬT ĐI (QUÂN XE)
    
}