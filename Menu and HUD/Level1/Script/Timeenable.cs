using UnityEngine;

public class Timeenable : MonoBehaviour
{
    public GameObject timeon;
    public GameObject timeoff;
    // Kéo cái object chứa Script GameTimer vào đây
    public GameObject timerObject; 

    void Start()
    {
        // Vừa vào màn là phải kiểm tra ngay bộ nhớ
        RefreshUI();
    }

    public void ToggleTime()
    {
        // Đọc giá trị hiện tại (1 là đang bật, 0 là đang tắt)
        int currentState = PlayerPrefs.GetInt("UseTimer", 1);
        
        // Đảo ngược nó lại
        int newState = (currentState == 1) ? 0 : 1;

        // Lưu lại ngay lập tức
        PlayerPrefs.SetInt("UseTimer", newState);
        PlayerPrefs.Save();

        // Cập nhật giao diện
        RefreshUI();
    }

   public void RefreshUI()
{
    int useTimer = PlayerPrefs.GetInt("UseTimer", 1);
    bool shouldShow = (useTimer == 1);

    if (timeon != null) timeon.SetActive(shouldShow);
    if (timeoff != null) timeoff.SetActive(!shouldShow);

    if (timerObject != null)
    {
        // 1. Tắt/Bật hiển thị của cả cụm đồng hồ
        timerObject.SetActive(shouldShow);
        
        // 2. Ép cái Script đếm giờ phải dừng lại
        var timerScript = timerObject.GetComponent<TimeCounting>();
        if (timerScript != null)
        {
            timerScript.isTimerRunning = shouldShow;
        }
    }
}
}