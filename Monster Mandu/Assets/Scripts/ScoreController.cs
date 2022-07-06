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
        GameManager.scoreValue = 0;
        GameManager.highScore = SaveLoadScore.LoadHighScore();
    }

    private void Update()
    {
        scoreText.text = "Score: " + GameManager.scoreValue; 
        highScoreText.text = $"HighScore: {GameManager.highScore.ToString()}";
    }
}
