using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    void Update()
    {
        scoreText.text = "Score: " + GameManager.scoreValue;
    }

    void Start()
    {
        InvokeRepeating("UpdateScore", 1.0f, 1.0f);
    }

    void UpdateScore()
    {
        if (GameManager.gameOver == true)
        {
            CancelInvoke();
            return;
        }
        GameManager.scoreValue += 1;
    }
}
