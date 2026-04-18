using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 👉 Vào màn chọn level
    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("Level");
    }

    // 👉 Load màn cụ thể (gọi từ button)
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    // 👉 Quay lại menu
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // 👉 Thoát game
    public void QuitGame()
    {
        Application.Quit();
    }
}