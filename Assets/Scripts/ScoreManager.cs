using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;

    int currentScore;

    void Awake()
    {
        instance = this;

        UpdateUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = $"Score: {currentScore.ToString("D5")}";
    }
}
