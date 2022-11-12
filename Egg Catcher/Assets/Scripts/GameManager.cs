using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public int Score {get; set;}
    static public int Life {get; set;}

    [SerializeField]
    public Text scoreObject;
    [SerializeField]
    public Text lifeObject;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Life = 10;
        Egg.ScoreChange += OnScoreChange;
    }

    void OnScoreChange() {
        scoreObject.text = "Score: " + Score.ToString();
        lifeObject.text = "Lives: " + Life.ToString();

        if (Life <= 0) {
            lifeObject.fontSize = 200;
            lifeObject.text = "Game Over";
            Time.timeScale = 0f;
        }
            
    }

}
