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
}
