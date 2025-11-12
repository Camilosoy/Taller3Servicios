using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GameController : MonoBehaviour
{
    [Header("Pelotas")]
    public GameObject redBallPrefab;
    public float spawnHeight = 7f;
    public float spawnXRange = 8f;
    public float initialSpawnInterval = 2f;
    public float minSpawnInterval = 0.3f;
    public float speedUpRate = 0.02f;

    private float timer = 0f;
    private float currentSpawnInterval;
    private float timePlayed = 0f;
    private int attempts = 1;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
    }

    void Update()
    {
        if (GameModel.Instance == null || GameModel.Instance.isGameOver) return;

        GameModel.Instance.score += Time.deltaTime * 10;
        timePlayed += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= currentSpawnInterval)
        {
            timer = 0f;
            SpawnBall();
        }

        
        currentSpawnInterval -= speedUpRate * Time.deltaTime;
        currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval);
    }

    void SpawnBall()
    {
        if (redBallPrefab == null)
        {
            Debug.LogError("Red Ball Prefab NO está asignado!");
            return;
        }

        float xPos = Random.Range(-spawnXRange, spawnXRange);
        Vector3 spawnPos = new Vector3(xPos, spawnHeight, 0);
        Instantiate(redBallPrefab, spawnPos, Quaternion.identity);
    }

    public void GameOver()
    {
        if (GameModel.Instance == null)
        {
            Debug.LogWarning("GameModel.Instance era null. Creando uno temporal...");
            var temp = new GameObject("GameModel");
            temp.AddComponent<GameModel>();
        }

        GameModel.Instance.isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("GAME OVER");

        
        // _ = SaveScoreToFirebase();
    }

    // private async Task SaveScoreToFirebase()
    // {
    //     await Firestore.SaveHighscore(GameModel.Instance.playerName, GameModel.Instance.score, timePlayed, attempts);
    // }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
