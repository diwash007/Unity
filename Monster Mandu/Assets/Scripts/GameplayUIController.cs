using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField]
    AudioSource buttonSFX;

    public void RestartGame()
    {
        buttonSFX.Play();
        SceneManager.LoadScene("Gameplay");
        GameManager.scoreValue = 0;
    }

    public void HomeButton()
    {
        buttonSFX.Play();
        SceneManager.LoadScene("MainMenu");
        GameManager.scoreValue = 0;
    }
}
