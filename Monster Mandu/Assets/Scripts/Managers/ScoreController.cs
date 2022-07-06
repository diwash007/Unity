using SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField]
        private Text scoreText;
        [SerializeField]
        private Text highScoreText;

        private void Start()
        {
            GameManager.HighScore = SaveLoadScore.LoadHighScore();
            highScoreText.text = "HighScore: " + GameManager.HighScore;
        }

        private void Update()
        {
            scoreText.text = "Score: " + GameManager.ScoreValue; 
            highScoreText.text = $"HighScore: {GameManager.HighScore.ToString()}";
        }
    }
}
