using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static int ScoreValue;
        public static int HighScore;

        public static GameManager Instance;

        [SerializeField]
        private GameObject[] characters;

        private int _charIndex;
        public int CharIndex
        {
            get; set;
        }

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }

        private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != "Gameplay") return;
            ScoreValue = 0;
            Instantiate(characters[CharIndex]);
        }
    }
}
