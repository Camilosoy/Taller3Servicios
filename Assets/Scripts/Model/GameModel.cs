using UnityEngine;

public class GameModel : MonoBehaviour
{
    public static GameModel Instance;

    public string playerName;
    public float score;
    public bool isGameOver;
    public int attempts = 0;

    private void Awake()
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

    public void ResetGame()
    {
        score = 0;
        isGameOver = false;
        attempts++;
    }
}
