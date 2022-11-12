using System;
using UnityEngine;

public class Egg : MonoBehaviour
{

    public static event Action ScoreChange;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Bowl")
            GameManager.Score += 10;
        else
            GameManager.Life -= 1;
        Destroy(gameObject);
        ScoreChange();
    }
}
