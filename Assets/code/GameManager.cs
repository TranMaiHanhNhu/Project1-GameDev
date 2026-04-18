using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int moveCount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ResetMoveCount()
    {
        moveCount = 0;
    }
}
