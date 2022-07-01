using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private int scoreValue;

    void Start()
    {
        InvokeRepeating("UpdateScore", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreValue;
    }

    void UpdateScore()
    {
        scoreValue += 1;
    }
}
