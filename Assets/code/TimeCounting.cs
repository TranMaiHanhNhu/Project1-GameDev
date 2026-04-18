using UnityEngine;
using TMPro;

public class TimeCounting : MonoBehaviour
{
   public TextMeshProUGUI timerText; // Kéo cái TimerText vào đây
    public float timeStart = 0; // Số giây bắt đầu (nếu đếm ngược)
    public bool isTimerRunning = false;

      void Start()
{
    // Bỏ đoạn tự SetActive(false) đi, để script quản lý từ bên ngoài
    int useTimer = PlayerPrefs.GetInt("UseTimer", 1);
    isTimerRunning = (useTimer == 1);
}

    void Update()
    {
        if (isTimerRunning)
        {
                timeStart += Time.deltaTime;
                DisplayTime(timeStart);
            
            
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Tính toán phút và giây từ số giây tổng
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = Mathf.FloorToInt((timeToDisplay % 1) * 100);


        // Định dạng hiển thị kiểu 00:00:00
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, Mathf.FloorToInt((timeToDisplay % 1) * 100));
    }
}
