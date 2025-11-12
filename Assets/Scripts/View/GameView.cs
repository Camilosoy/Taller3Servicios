using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GameView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI rankingText; 
    public Button returnButton;

    private GameController gameController;

    void Start()
    {
        gameController = FindFirstObjectByType<GameController>();
        gameOverPanel.SetActive(false);
        returnButton.onClick.AddListener(() => gameController.ReturnToMenu());
    }

    void Update()
    {
        if (GameModel.Instance == null) return;

        if (!GameModel.Instance.isGameOver)
        {
            scoreText.text = $"Puntaje: {Mathf.FloorToInt(GameModel.Instance.score)}";
        }
        else
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = $"GAME OVER\nPuntaje final: {Mathf.FloorToInt(GameModel.Instance.score)}";
            // _ = LoadRanking();
        }
    }

    // private async Task LoadRanking()
    // {
    //     if (rankingText == null) return;

    //     List<(string name, int score)> topScores = await Firestore.GetTopScores(5);

    //     string rankingDisplay = "\n🏆 TOP 5 🏆\n";
    //     int pos = 1;
    //     foreach (var entry in topScores)
    //     {
    //         rankingDisplay += $"{pos}. {entry.name} — {entry.score}\n";
    //         pos++;
    //     }

    //     rankingText.text = rankingDisplay;
    // }
}
