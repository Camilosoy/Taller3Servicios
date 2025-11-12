using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void StartGame()
    {
        GameModel.Instance.playerName = nameInput.text;
        GameModel.Instance.ResetGame();
        SceneManager.LoadScene("Game");
    }
}

