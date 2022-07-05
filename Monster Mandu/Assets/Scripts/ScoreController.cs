using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay")
            scoreText.text = "Score: " + GameManager.scoreValue;
        else
            scoreText.text = "Score: " + GameManager.finalScore;
    }

    void Start()
    {
        InvokeRepeating("UpdateScore", 1.0f, 1.0f);
    }

    void UpdateScore()
    {
        if (GameManager.gameOver == true)
        {   
            GameManager.gameOver = false;
            GameManager.finalScore = GameManager.scoreValue;
            return;
        }
        GameManager.scoreValue += 1;
    }
}
