using UnityEngine;
using TMPro;

public class WinUI : MonoBehaviour
{
    public TextMeshProUGUI winText;

    void Start()
    {
        int moves = GameManager.Instance.moveCount; // hoặc Instance nếu bạn dùng cách 2
        winText.text = "Thắng sau " + moves + " nước";
        GameManager.Instance.ResetMoveCount(); // Đặt lại moveCount sau khi hiển thị kết quả
    }
}