using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource buttonSfx;

        public void PlayGame()
        {
            buttonSfx.Play();
            var selectedCharacter =
                int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            GameManager.Instance.CharIndex = selectedCharacter;

            SceneManager.LoadScene("Gameplay");

        }
    }
}
