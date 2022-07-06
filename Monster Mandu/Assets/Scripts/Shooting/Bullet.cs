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
            GameManager.scoreValue += 5;
            SaveScore();
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        
        private void SaveScore()
        {
            if(GameManager.scoreValue <= GameManager.highScore) return;
            GameManager.finalScore = GameManager.scoreValue;
        }
    }
}
