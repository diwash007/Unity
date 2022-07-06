using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameplayUIController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource buttonSfx;

        public void RestartGame()
        {
            buttonSfx.Play();
            SceneManager.LoadScene("Gameplay");
            GameManager.ScoreValue = 0;
        }

        public void HomeButton()
        {
            buttonSfx.Play();
            SceneManager.LoadScene("MainMenu");
            GameManager.ScoreValue = 0;
        }
    }
}
