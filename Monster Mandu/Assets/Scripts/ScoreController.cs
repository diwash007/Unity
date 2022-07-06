using SaveLoad;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;

    private void Start()
    {
        GameManager.highScore = SaveLoadScore.LoadHighScore();
        highScoreText.text = $"HighScore: {GameManager.highScore.ToString()}";
    }

    private void Update()
    {
        scoreText.text = "Score: " + GameManager.scoreValue;
    }
}
