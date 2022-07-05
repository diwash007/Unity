using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
        GameManager.scoreValue = 0;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.scoreValue = 0;
    }
}
