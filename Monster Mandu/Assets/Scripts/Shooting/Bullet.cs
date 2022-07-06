using Enemy;
using Managers;
using SaveLoad;
using UnityEngine;

namespace Shooting
{
    public class Bullet : MonoBehaviour
    {
        private const string Enemy = "Enemy";

        [SerializeField]
        private ParticleSystem hitParticle;
        
        private void OnEnable()
        {
            Destroy(gameObject, 0.3f);
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag(Enemy)) return;

            col.gameObject.TryGetComponent<Monster>(out var monster);
            monster.PlayDeathAudio();
            
            var particle = Instantiate(hitParticle, transform.position, Quaternion.identity);
            particle.Play();
            GameManager.ScoreValue += 5;
            SaveScore();
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        
        private static void SaveScore()
        {
            if(GameManager.ScoreValue <= GameManager.HighScore) return;
            print("Saved");
            SaveLoadScore.SaveHighScore(GameManager.ScoreValue);
            GameManager.HighScore = GameManager.ScoreValue;
        }
    }
}
