using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverText;

    public void ShowGameOver()
    {
        Debug.Log("Game over");
        gameOverText.SetActive(true);
    }
}