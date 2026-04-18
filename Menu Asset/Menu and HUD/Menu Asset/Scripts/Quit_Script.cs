using UnityEngine;

public class Quit_Script : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
