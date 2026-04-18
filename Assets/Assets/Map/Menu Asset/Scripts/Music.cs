using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject iconOn;
    public GameObject iconOff;

    // Hàm này tự chạy mỗi khi Scene được load xong
    void Start()
    {
        // Vừa vào màn là kiểm tra ngay xem lúc trước người ta có tắt nhạc không
        RefreshUI();
    }

    public void ToggleMusic()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
        
        // Đổi tiếng xong thì đổi hình ngay lập tức
        RefreshUI();
    }

    // Hàm phụ trách việc hiển thị đúng Icon dựa trên âm lượng tổng
    public void RefreshUI()
    {
        if (AudioListener.volume == 0)
        {
            iconOn.SetActive(false);
            iconOff.SetActive(true);
        }
        else
        {
            iconOn.SetActive(true);
            iconOff.SetActive(false);
        }
    }
}